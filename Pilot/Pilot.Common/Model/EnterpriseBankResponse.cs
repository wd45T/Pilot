using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class EnterpriseBankResponse
    {
        public Guid Id { get; set; } 
        public Guid EnterpriseId { get; set; } 
        public Guid BankId { get; set; }         
    }                     
}
