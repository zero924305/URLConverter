using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace URLConverter
{

    public static class DB
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Startup.StaticConfig["ConnectionStrings:demoDB"]);
        }
    }

}
