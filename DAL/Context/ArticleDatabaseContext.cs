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
        //todo: connection classe maken
        private static string ConnectionString = @"Data Source=mssql.fhict.local;Initial Catalog=dbi384367;Persist Security Info=True;User ID=dbi384367;Password=Database8";
        private List<Article> articles = new List<Article>();

        public ArticleDatabaseContext()
        {
            //todo: using gaan gebruiken
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = "SELECT * FROM [Article]";
            SqlCommand command = new SqlCommand(query, connection);
            var model = new List<Article>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var article = new Article
                {
                    ArticleId = Convert.ToInt32(reader["ArticleId"]),
                    Title = reader["Title"].ToString(),
                    Category = reader["Category"].ToString(),
                    Content = reader["Content"].ToString(),
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
