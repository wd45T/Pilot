using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.DataCore
{
    public partial class DataManager
    {
        public DataManager(string connectionString) : base("SqlServer", connectionString) { }
    }
}
