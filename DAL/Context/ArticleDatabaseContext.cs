using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MDL;

namespace DAL.Contexts
{
    public class ArticleDatabaseContext : IArticleContext
    {
        private static string ConnectionString = @"Data Source=mssql.fhict.local;Initial Catalog=dbi384367;Persist Security Info=True;User ID=dbi384367;Password=Database8";
        private List<Article> articles = new List<Article>();

        public ArticleDatabaseContext()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = "SELECT * FROM [Article]";
            SqlCommand command = new SqlCommand(query, connection);
            var model = new List<Article>();
            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                var article = new Article
                {
                    ArticleId = Convert.ToInt32(rdr["ArticleId"]),
                    Title = rdr["Title"].ToString(),
                    Category = rdr["Category"].ToString(),
                    Content = rdr["Content"].ToString(),
                    //Image = GetImageForProduct(Convert.ToInt32(rdr["Image"]))
                };

                model.Add(article);
                model.ToList();
                articles = model;
            }
            connection.Close();

        }

        public List<Article> GetAllArticles() => articles;
        
    }
}
