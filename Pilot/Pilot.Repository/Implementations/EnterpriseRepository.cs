using AutoMapper.QueryableExtensions;
using LinqToDB;
using Pilot.Common.Model;
using Pilot.DataCore;
using Pilot.Repository.BaseClasses;
using Pilot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Repository.Implementations
{
    public class EnterpriseRepository : BaseRepository<Enterprise, EnterpriseResponse>, IEnterpriseRepository
    {
        public EnterpriseRepository(DataManager dataManager) : base(dataManager) { }

        public async override Task<ICollection<EnterpriseResponse>> GetDtoAll()
        {
            var enterprise = await _dataManager.Enterprise
                .LoadWith(x=>x.ManagerRef)
                .Where(x => !x.Deleted.HasValue)
                .ProjectTo<EnterpriseResponse>()
                .ToListAsync();

            enterprise.ForEach(x =>
            {
                x.Banks = _dataManager.EnterpriseBank
                    .Where(y => y.EnterpriseId == x.Id)
                    .Select(y=>y.BankRef)
                    .ProjectTo<BankResponse>();
                x.PaymentAccounts = _dataManager.PaymentAccount
                    .Where(y => y.EnterpriseId == x.Id)
                    .ProjectTo<PaymentAccountResponse>();
            });

            return enterprise;
        }

        public async override Task<EnterpriseResponse> GetDtoById(Guid id)
        {
            var enterpris = AutoMapper.Mapper.Map<EnterpriseResponse>
                (await _dataManager.Enterprise
                    .LoadWith(x => x.ManagerRef)
                    .FirstOrDefaultAsync(x => !x.Deleted.HasValue));

            enterpris.Banks = _dataManager.EnterpriseBank
                .Where(y => y.EnterpriseId == enterpris.Id)
                .Select(y => y.BankRef)
                .ProjectTo<BankResponse>();
            enterpris.PaymentAccounts = _dataManager.PaymentAccount
                .Where(y => y.EnterpriseId == enterpris.Id)
                .ProjectTo<PaymentAccountResponse>();

            return enterpris;
        }
    }
}
