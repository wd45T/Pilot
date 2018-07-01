using AutoMapper;
using LinqToDB;
using Pilot.Common.Model;
using Pilot.DataCore;
using Pilot.Repository.BaseClasses;
using Pilot.Repository.Interfaces;
using Pilot.Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Repository.Implementations
{
    public class BankRepository : BaseRepository<Bank, BankResponse>, IBankRepository
    {
        public BankRepository(DataManager dataManager) : base(dataManager) { }

        public async Task<BankResponse> GetBankByBIK(string bik)
            => Mapper.Map<BankResponse>(await _dataManager.Bank
                .FirstOrDefaultAsync(x => !x.Deleted.HasValue && x.BIK == bik));
    }
}
