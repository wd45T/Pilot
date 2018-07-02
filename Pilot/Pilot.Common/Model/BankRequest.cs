using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class BankRequest
    {
        public string FullNameBank { get; set; }
        public string AddressBank { get; set; }
        public string BIK { get; set; }
        public string CorrespondingAccount { get; set; }
    }
}
