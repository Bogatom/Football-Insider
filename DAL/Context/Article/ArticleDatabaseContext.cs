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
        Connection database = new Connection();
        private List<Article> articles = new List<Article>();


        public List<Article> GetAllArticles()
        {
            string query = "SELECT * FROM [Article]";
            var model = new List<Article>();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var article = new Article
                                {
                                    ArticleId = Convert.ToInt32(reader["ArticleId"]),
                                    Title = reader["Title"].ToString(),
                                    Category = reader["Category"].ToString(),
                                    Content = reader["Content"].ToString(),
                                    //Image = GetImageForArticle(Convert.ToInt32(reader["Image"]))
                                };

                                model.Add(article);
                                model.ToList();
                                articles = model;                              
                            }
                        }
                        connection.Close();
                    }
                }
                return articles;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }      
    }
}
