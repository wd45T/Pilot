using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model.Common
{
    public class MetaResponse
    {
        public long TotalCount { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
