using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class LocalConnection
    {
        public string GetConnectionString()
        {
            string result =
                @"Data Source=DESKTOP-9DG53HK\TOMSQL;Initial Catalog=Football_Insider;Integrated Security=True;";
            return result;
        }
    }
}