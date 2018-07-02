using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class BankResponse
    {
        public Guid Id { get; set; }
        public string FullNameBank { get; set; }
        public string AddressBank { get; set; }
        public string BIK { get; set; }
        public string CorrespondingAccount { get; set; }
    }
}
