using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL;
using System.Web;
using Interfaces_BLL_DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Contexts.File
{
    public class FileDatabaseContext : IFileContext
    {
        Connection database = new Connection();
        private List<FileModel> fileModels = new List<FileModel>();

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            FileModel NewFile = new FileModel();

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Int32 rowsAffected;

                        cmd.CommandText = "AddFile";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ArticleId;
                        cmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = Path;
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return NewFile;
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
        public FileModel DeleteFile(int ArticleID, int FileID)
        {
            FileModel fileModel = new FileModel();

            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        Int32 rowsAffected;

                        cmd.CommandText = "DeleteFile";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.Add("@Article_ID", SqlDbType.Int).Value = ArticleID;
                        cmd.Parameters.Add("@File_ID", SqlDbType.Int).Value = FileID;

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return fileModel;
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
        public FileModel GetCurrentFile(int ArticleID, string File)
        {
            FileModel fileModel = new FileModel();

            string fileQuery = "SELECT Files.[File_ID] FROM Files INNER JOIN Article_Files ON Files.[File_ID] = Article_Files.[File_ID] WHERE Article_Files.[Article_ID] = @Article_ID AND Files.[FilePath] = @FilePath";
            using (SqlConnection connection = new SqlConnection(database.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    FileModel file = new FileModel();
                    using (SqlCommand FileCommand = new SqlCommand(fileQuery, connection))
                    {
                        FileCommand.Parameters.Add(new SqlParameter("@Article_ID", ArticleID));
                        FileCommand.Parameters.Add(new SqlParameter("@FilePath", File));
                        FileCommand.ExecuteScalar();

                        using (SqlDataReader reader = FileCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fileModel.File_ID = Convert.ToInt32(reader["File_ID"]);
                            }
                        }
                    }
                    connection.Close();
                    return fileModel;
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
        public List<FileModel> GetAllFiles()
        {

            string query = "SELECT * FROM [Files]";
            var model = new List<FileModel>();

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
                                var fileModel = new FileModel
                                {
                                    Article_ID = Convert.ToInt32(reader["Article_ID"]),
                                    File_ID = Convert.ToInt32(reader["File_ID"]),
                                    FilePath = reader["FilePath"].ToString()
                                };

                                model.Add(fileModel);
                                model.ToList();
                                fileModels = model;
                            }
                        }

                        connection.Close();
                    }
                    return fileModels;
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
