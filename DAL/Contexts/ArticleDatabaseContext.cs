using MDL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAL.Contexts
{
    public class ArticleDatabaseContext : IArticleContext
    {
        private static string ConnectionString =
            "Data Source=mssql.fhict.local;Initial Catalog=dbi384367;Persist Security Info=True;User ID=dbi384367;Password=Database8";
        private List<Article> articles = new List<Article>();

        public ArticleDatabaseContext()
        {
            sqlconnection
        }

        public IEnumerable<Article> GetAll()
        {
            return articles;
        }
    }
}
