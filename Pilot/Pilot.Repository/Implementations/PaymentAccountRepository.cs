using Pilot.Common.Model;
using Pilot.DataCore;
using Pilot.Repository.BaseClasses;
using Pilot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Repository.Implementations
{
    public class PaymentAccountRepository : BaseRepository<PaymentAccount, PaymentAccountResponse>, IPaymentAccountRepository
    {
        public PaymentAccountRepository(DataManager dataManager) : base(dataManager) { }
    }
}
