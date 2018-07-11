using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class TypeDocData
    {
        public string ContractNumber { get; set; }
        public string PrepaidExpense { get; set; }
        public string PrepaidExpenseInWords { get; set; }
        public string BalancePrice { get; set; }
        public string BalancePriceInWords { get; set; }

        public EnterpriseResponse Enterprise { get; set; }
        public BankResponse Bank { get; set; }
        public PaymentAccountResponse PaymentAccount { get; set; }

        public List<List<string>> Rows { get; set; }

    }

}
