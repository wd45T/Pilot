using Pilot.Common.Model;
using Pilot.DataCore;
using Pilot.Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Repository.Interfaces
{
    public interface IBankRepository : IReadRepository<Bank, BankResponse>
    {
        Task<BankResponse> GetBankByBIK(string bik);
    }
}
