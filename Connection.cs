using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PAPYRUS
{
    internal class Connection
    {
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-7J609NM\SQL_DEV_DAVID_22;Initial Catalog=Papyrus;Persist Security Info=True;User ID=sa;Password=David1996@1;Trust Server Certificate = True");
            connection.Open();
            return connection;
        }
    }
}
