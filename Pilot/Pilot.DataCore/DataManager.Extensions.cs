using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.DataCore
{
    public partial class DataManager
    {
        public DataManager(string connectionString) : base( new SqlServerDataProvider(ProviderName.SqlServer2012, SqlServerVersion.v2012) , connectionString) { }
    }
}
