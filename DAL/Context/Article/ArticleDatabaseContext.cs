using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MDL;
using System.Web;

namespace DAL.Contexts
{
    public class ArticleDatabaseContext : IArticleContext
    {
        Connection database = new Connection();
        private List<Article> articles = new List<Article>();
        private List<Category> categories = new List<Category>();


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


        public Article AddArticle(BindModel article)
        {
            string query = "Insert INTO Article (Title, Content) " + "Values (@Title, @Content); SELECT SCOPE_IDENTITY()";
            Article NewArtile = new Article();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.Text,
                        CommandText = query,
                        Parameters =
                        {
                            new SqlParameter("@Title", article._Article.Title),
                            new SqlParameter("@Content", article._Article.Content),
                        }
                    };

                    NewArtile.ArticleId = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return NewArtile;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            string query = "Insert INTO Files (FilePath, ArticleId) " + "Values (@FilePath, @ArticleId); SELECT SCOPE_IDENTITY()";
            FileModel newFile = new FileModel();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand AddFileCommand = new SqlCommand(query, connection))
                    {
                        AddFileCommand.Parameters.Add(new SqlParameter("@FilePath", Path));
                        AddFileCommand.Parameters.Add(new SqlParameter("@ArticleId", ArticleId));

                        AddFileCommand.ExecuteScalar();
                    }
                    connection.Close();
                    return newFile;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM [Category]";
            var model = new List<Category>();

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
                                var category = new Category
                                {
                                    CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                    CategoryName = reader["CategoryName"].ToString(),
                                };

                                model.Add(category);
                                model.ToList();
                                categories = model;
                            }
                        }
                        connection.Close();
                    }
                }
                return categories;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
