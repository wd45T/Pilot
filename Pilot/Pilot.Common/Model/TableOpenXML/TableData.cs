using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model.TableOpenXML
{
    public class TableData
    {
        public IEnumerable<string> HeaderTable { get; set; }
        public IEnumerable<IEnumerable<string>> Rows { get; set; }
    }
}
