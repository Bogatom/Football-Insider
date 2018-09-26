using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Connection
    {
        SqlConnection myConnection = new SqlConnection();
        SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

        public Connection()
        {
            myBuilder.UserID = "dbi384367";
            myBuilder.Password = "Database8";
            myBuilder.InitialCatalog = "dbi384367";
            myBuilder.DataSource = "mssql.fhict.local";
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