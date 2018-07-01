using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class PaymentAccountResponse
    {                                          
        public Guid Id { get; set; } 
        public string Account { get; set; } 
        public Guid BankId { get; set; } 
    }
}
