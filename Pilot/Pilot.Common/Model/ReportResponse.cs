using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class ReportResponse
    {
        public string ContractNumber{ get; set; }
        public string Enterprise { get; set; }
        public string EnterprisePerson { get; set; }
        public string Base { get; set; }
        public string SectionAddress { get; set; }
        public string SectionRole { get; set; }
        public string SectionArea { get; set; }
        public string ContractPrice { get; set; }
    }

}
