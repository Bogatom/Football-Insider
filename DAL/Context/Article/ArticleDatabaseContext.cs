using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MDL;
using System.Web;
using Interfaces_BLL_DAL;

namespace DAL.Context
{
    public class ArticleDatabaseContext : IArticleContext
    {
        Connection database = new Connection();
        private List<Article> articles = new List<Article>();

        public List<Article> GetAllArticles()
        {
            string query = "SELECT * FROM [Article]";
            var model = new List<Article>();

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var article = new Article
                                {
                                    ArticleId = Convert.ToInt32(reader["Article_ID"]),
                                    Title = reader["Title"].ToString(),
                                    Category = GetCategoryForArticle(Convert.ToInt32(reader["Category_ID"])),
                                    CreationDate = reader["CreationDate"].ToString(),
                                    Content = reader["Content"].ToString(),
                                    Image = GetImageForArticle(Convert.ToInt32(reader["Article_ID"]))
                                };

                                model.Add(article);
                                model.ToList();
                                articles = model;
                            }
                        }

                        connection.Close();
                    }
                    return articles;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (InvalidCastException invalidCastException)
                {
                    throw invalidCastException;
                }
            }
        }

        public string GetCategoryForArticle(int category_id)
        {
            Category category = new Category();
            string categoryQuery = "SELECT * FROM Category WHERE Category_ID = @Category_ID";
            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    FileModel file = new FileModel();
                    using (SqlCommand CateogryCommand = new SqlCommand(categoryQuery, connection))
                    {
                        CateogryCommand.Parameters.Add(new SqlParameter("@Category_ID", category_id));
                        CateogryCommand.ExecuteScalar();

                        using (SqlDataReader reader = CateogryCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                category.CategoryId = Convert.ToInt32(reader["Category_ID"]);
                                category.CategoryName = (string)reader["CategoryName"];
                            }
                        }
                        connection.Close();
                    }
                    return category.CategoryName;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (InvalidCastException invalidCastException)
                {
                    throw invalidCastException;
                }
            }
        }

        internal List<string> GetImageForArticle(int articleId)
        {
            Article article = new Article();

            string imageQuery = "SELECT Article_ID, dbo.[Article_Files].[File_ID], dbo.[Files].FilePath FROM Article_Files INNER JOIN dbo.Files ON dbo.Article_Files.[File_ID] = dbo.Files.[File_ID] AND [Article_Files].[Article_ID] = @Article_ID";
            var files = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    try
                    {
                        connection.Open();
                        FileModel file = new FileModel();
                        using (SqlCommand AddImageForArticle = new SqlCommand(imageQuery, connection))
                        {
                            AddImageForArticle.Parameters.Add(new SqlParameter("@Article_ID", articleId));
                            AddImageForArticle.ExecuteScalar();

                            using (SqlDataReader reader = AddImageForArticle.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    file.Article_ID = Convert.ToInt32(reader["Article_ID"]);
                                    file.FilePath = (string)reader["FilePath"];
                                    files.Add(file.FilePath);
                                }
                            }
                            connection.Close();
                        }
                        return files;
                    }
                    catch (SqlException sqlException)
                    {
                        throw sqlException;
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw invalidCastException;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
            
        }

        public Article AddArticle(Article article)
        {
            string query = "Insert INTO Article (Title, Content, CreationDate) " + "Values (@Title, @Content, @CreationDate); SELECT SCOPE_IDENTITY()";
            Article NewArtile = new Article();

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand AddArticleCommand = new SqlCommand(query, connection))
                    {
                        AddArticleCommand.Parameters.Add(new SqlParameter("@Title", article.Title));
                        AddArticleCommand.Parameters.Add(new SqlParameter("@Content", article.Content));
                        AddArticleCommand.Parameters.Add(new SqlParameter("@CreationDate", DateTime.Now));
                        NewArtile.ArticleId = Convert.ToInt32(AddArticleCommand.ExecuteScalar());
                    }
                    connection.Close();
                    return NewArtile;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (InvalidCastException invalidCastException)
                {
                    throw invalidCastException;
                }
            }
        }

        public Category AddCategoryToArticle(int id, string CategoryName)
        {
            string CategoryQuery =
                "UPDATE Article SET Category_ID = (SELECT Category_ID FROM Category WHERE CategoryName = @CategoryName) WHERE Article_ID = @Article_ID; SELECT SCOPE_IDENTITY()";
            Category category = new Category();

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand AddCategoryCommand = new SqlCommand(CategoryQuery, connection))
                    {
                        AddCategoryCommand.Parameters.Add(new SqlParameter("@Article_ID", id));
                        AddCategoryCommand.Parameters.Add(new SqlParameter("@CategoryName", CategoryName));
                        AddCategoryCommand.ExecuteScalar();
                    }
                    connection.Close();
                    return category;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }

                catch (InvalidCastException invaldCastException)
                {
                    throw invaldCastException;
                }
            }
        }
    
        public Article GetCurrentArticle(int articleId)
        {
            string ArticleQuery = "SELECT * FROM Article WHERE Article_ID = @id; SELECT SCOPE_IDENTITY()";
            Article NewArticle = new Article();
            
            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand GetArticleCommand = new SqlCommand(ArticleQuery, connection))
                    {
                        GetArticleCommand.Parameters.Add(new SqlParameter("@id", articleId));
                        using (SqlDataReader reader = GetArticleCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var article = new Article()
                                {
                                    ArticleId = Convert.ToInt32(reader["Article_ID"]),
                                    Title = reader["Title"].ToString(),
                                    Content = reader["Content"].ToString(),
                                    Category = GetCategoryForArticle(Convert.ToInt32(reader["Category_ID"])),
                                    CreationDate = reader["CreationDate"].ToString(),
                                    Image = GetImageForArticle(Convert.ToInt32(reader["Article_ID"]))
                                };
                                NewArticle = article;
                            }
                        }
                    }
                    connection.Close();
                    return NewArticle;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (InvalidCastException invalidCastException)
                {
                    throw invalidCastException;
                }
            }          
        }

        public Article EditArticle(Article EditedArticle)
        {
            string query = "UPDATE Article SET Title = @Title, Content = @Content, CreationDate = @CreationDate WHERE Article_ID = @Article_ID; SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand EditArticleCommand = new SqlCommand(query, connection))
                    {
                        EditArticleCommand.Parameters.Add(new SqlParameter("@Article_ID", EditedArticle.ArticleId));
                        EditArticleCommand.Parameters.Add(new SqlParameter("@Title", EditedArticle.Title));
                        EditArticleCommand.Parameters.Add(new SqlParameter("@Content", EditedArticle.Content));
                        EditArticleCommand.Parameters.Add(new SqlParameter("@CreationDate", DateTime.Now));
                        EditArticleCommand.ExecuteScalar();
                    }
                    connection.Close();

                    EditedArticle.Image = GetImageForArticle(EditedArticle.ArticleId);
                    return EditedArticle;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (InvalidCastException invalidCastException)
                {
                    throw invalidCastException;
                }
            }          
        }     

        public Article DeleteArticle(int articleId)
        {
            Article article = new Article();

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Int32 rowsAffected;

                        cmd.CommandText = "DeleteArticle";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.Add("@Article_ID", SqlDbType.Int).Value = articleId;

                        connection.Open();

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return article;
                }
                catch (SqlException sqlException)
                {
                    throw sqlException;
                }
                catch (InvalidCastException invalidCastException)
                {
                    throw invalidCastException;
                }
            }                  
        }
    }
}
