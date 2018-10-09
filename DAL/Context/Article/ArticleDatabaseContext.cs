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
                                    CreationDate = reader["CreationDate"].ToString(),
                                    Content = reader["Content"].ToString(),
                                    Image = GetImageForArticle(Convert.ToInt32(reader["ArticleId"]))
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
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }

        internal List<string> GetImageForArticle(int articleId)
        {
            Article article = new Article();

            string imageQuery = "SELECT * From Files Where ArticleId = @Id";
            var files = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    connection.Open();
                    FileModel file = new FileModel();
                    using (SqlCommand AddImageForArticle = new SqlCommand(imageQuery, connection))
                    {
                        AddImageForArticle.Parameters.Add(new SqlParameter("@id", articleId));
                        AddImageForArticle.ExecuteScalar();

                        using (SqlDataReader reader = AddImageForArticle.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                file.ArticleId = Convert.ToInt32(reader["ArticleId"]);
                                file.FilePath = (string)reader["FilePath"];
                                files.Add(file.FilePath.Replace("~", ""));
                            }
                        }
                    }
                }
                return files;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            
        }


        public Article AddArticle(BindModel article)
        {
            string query = "Insert INTO Article (Title, Content, CreationDate) " + "Values (@Title, @Content, @CreationDate); SELECT SCOPE_IDENTITY()";
            Article NewArtile = new Article();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand AddArticleCommand = new SqlCommand(query, connection))
                    {
                        AddArticleCommand.Parameters.Add(new SqlParameter("@Title", article._Article.Title));
                        AddArticleCommand.Parameters.Add(new SqlParameter("@Content", article._Article.Content));
                        AddArticleCommand.Parameters.Add(new SqlParameter("@CreationDate", DateTime.Now));

                        NewArtile.ArticleId = Convert.ToInt32(AddArticleCommand.ExecuteScalar());
                    }
                    connection.Close();
                    return NewArtile;
                }
            }
                               
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            string fileQuery = "Insert INTO Files (FilePath, ArticleId) " + "Values (@FilePath, @ArticleId); SELECT SCOPE_IDENTITY()";
            FileModel NewFile = new FileModel();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand AddFileCommand = new SqlCommand(fileQuery, connection))
                    {
                        AddFileCommand.Parameters.Add(new SqlParameter("@FilePath", Path));
                        AddFileCommand.Parameters.Add(new SqlParameter("@ArticleId", ArticleId));
                        NewFile.ArticleId = Convert.ToInt32(AddFileCommand.ExecuteScalar());
                    }
                    connection.Close();
                    return NewFile;
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
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
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }

        public Category AddCategoryToArticle(int id, string CategoryName)
        {
            string CategoryQuery = "UPDATE Article SET Category = @Category WHERE ArticleId = @id; SELECT SCOPE_IDENTITY()";
            Category category = new Category();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand AddCategoryCommand = new SqlCommand(CategoryQuery, connection))
                    {
                        AddCategoryCommand.Parameters.Add(new SqlParameter("@id", id));
                        AddCategoryCommand.Parameters.Add(new SqlParameter("@Category", CategoryName));
                        AddCategoryCommand.ExecuteScalar();
                    }
                    connection.Close();
                    return category;
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }
    }
}
