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
                }
                return articles;
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }

        public string GetCategoryForArticle(int category_id)
        {
            Category category = new Category();
            string categoryQuery = "SELECT * FROM Category WHERE Category_ID = @Category_ID";
            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
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
                }
            }
            return category.CategoryName;
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
            FileModel NewFile = new FileModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Int32 rowsAffected;

                        cmd.CommandText = "AddFile";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleId;
                        cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = Path;

                        connection.Open();

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
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
                                    CategoryId = Convert.ToInt32(reader["Category_ID"]),
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
            string CategoryQuery = "UPDATE Article SET Category_ID = (SELECT Category_ID FROM Category WHERE CategoryName = @CategoryName) WHERE Article_ID = @Article_ID; SELECT SCOPE_IDENTITY()";
            Category category = new Category();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
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
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }
        }

        public Article GetCurrentArticle(int articleId)
        {
            string ArticleQuery = "SELECT * FROM Article WHERE Article_ID = @id; SELECT SCOPE_IDENTITY()";
            Article NewArticle = new Article();
            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
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
                                    CreationDate =  reader["CreationDate"].ToString(),
                                    Image = GetImageForArticle(Convert.ToInt32(reader["Article_ID"]))
                                };
                                NewArticle = article;
                            }
                        }
                    }
                    connection.Close();
                    return NewArticle;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Article EditArticle(BindModel EditedArticle)
        {
            string query = "UPDATE Article SET Title = @Title, Content = @Content, CreationDate = @CreationDate WHERE Article_ID = @Article_ID; SELECT SCOPE_IDENTITY()";
            Article NewArticle = new Article();

            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand EditArticleCommand = new SqlCommand(query, connection))
                    {
                        EditArticleCommand.Parameters.Add(new SqlParameter("@Article_ID", EditedArticle._Article.ArticleId));
                        EditArticleCommand.Parameters.Add(new SqlParameter("@Title", EditedArticle._Article.Title));
                        EditArticleCommand.Parameters.Add(new SqlParameter("@Content", EditedArticle._Article.Content));
                        EditArticleCommand.Parameters.Add(new SqlParameter("@CreationDate", DateTime.Now));
                        EditArticleCommand.ExecuteScalar();
                    }
                    connection.Close();

                    NewArticle.ArticleId  = EditedArticle._Article.ArticleId;
                    NewArticle.Title = EditedArticle._Article.Title;
                    NewArticle.Content = EditedArticle._Article.Content;
                    NewArticle.Image = GetImageForArticle(EditedArticle._Article.ArticleId);
                    NewArticle.CreationDate = DateTime.Now.ToString();

                    EditedArticle._Article = NewArticle;
                    return EditedArticle._Article;
                }
            }

            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }     

        public Article DeleteArticle(int articleId)
        {
            Article article = new Article();
            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
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
                }
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public FileModel DeleteFile(int ArticleID, int FileID)
        {
            FileModel fileModel = new FileModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Int32 rowsAffected;

                        cmd.CommandText = "DeleteFile";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.Add("@Article_ID", SqlDbType.Int).Value = ArticleID;
                        cmd.Parameters.Add("@File_ID", SqlDbType.Int).Value = FileID;

                        connection.Open();

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                return fileModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public FileModel GetCurrentFile(int ArticleID, string File)
        {
            FileModel fileModel = new FileModel();
            try
            {
                    string fileQuery = "SELECT Files.[File_ID] FROM Files INNER JOIN Article_Files ON Files.[File_ID] = Article_Files.[File_ID] WHERE Article_Files.[Article_ID] = @Article_ID AND Files.[FilePath] = @FilePath";
                    using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
                    {
                        connection.Open();
                        FileModel file = new FileModel();
                        using (SqlCommand FileCommand = new SqlCommand(fileQuery, connection))
                        {
                            FileCommand.Parameters.Add(new SqlParameter("@Article_ID", ArticleID));
                            FileCommand.Parameters.Add(new SqlParameter("@FilePath", "~"+File));
                            FileCommand.ExecuteScalar();

                            using (SqlDataReader reader = FileCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    fileModel.File_ID = Convert.ToInt32(reader["File_ID"]);
                                }
                            }
                        }
                        return fileModel;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
