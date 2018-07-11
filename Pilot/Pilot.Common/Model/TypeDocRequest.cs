using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class TypeDocRequest
    {
        public string ContractNumber { get; set; }
        public string PrepaidExpense { get; set; }
        public string PrepaidExpenseInWords { get; set; }
        public string BalancePrice { get; set; }
        public string BalancePriceInWords { get; set; }

        public Guid EnterpriseId { get; set; }
        public Guid BankId { get; set; }
        public Guid PaymentAccountId { get; set; }

        public List<List<string>> Rows { get; set; }
    }
}
