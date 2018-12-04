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
        SqlConnection myConnection = new SqlConnection();
        SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

        public LocalConnection()
        {
            myBuilder.UserID = "";
            myBuilder.Password = "";
            myBuilder.InitialCatalog = "Football_Insider";
            myBuilder.DataSource = @"DESKTOP - 9DG53HK\TOMSQL";
            myBuilder.PersistSecurityInfo = true;
            myConnection.ConnectionString = myBuilder.ConnectionString;
        }

        public string GetConnectionString()
        {
            string result = myBuilder.ConnectionString;
            return result;
        }
    }
}