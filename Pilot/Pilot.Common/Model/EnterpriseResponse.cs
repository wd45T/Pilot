using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{                                                  
    public class EnterpriseResponse
    {
        public Guid   Id { get; set; } 
        public string TypeEnterprise { get; set; } 
        public string FullName { get; set; } 
        public string Position { get; set; } 
        public Guid   ManagerId { get; set; } 
        public string ManagerName { get; set; } 
        public string InPersonManager { get; set; }
        public string Base { get; set; }
        public string INN { get; set; } 
        public string KPP { get; set; } 
        public string OGRN { get; set; }
        public string LegalAddress { get; set; } 
        public string MailingAddress { get; set; } 
        public string PhoneFax { get; set; } 
        public string Email { get; set; } 
        public string Passport { get; set; } 
        public IEnumerable<BankResponse> Banks { get; set; }
        public IEnumerable<PaymentAccountResponse> PaymentAccounts { get; set; }
    }
}
