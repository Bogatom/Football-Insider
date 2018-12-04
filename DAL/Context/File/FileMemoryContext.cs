using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Interfaces_BLL_DAL;
using MDL;

namespace DAL.Context
{
    public class FileMemoryContext : IFileContext
    {
        LocalConnection LocalDatabase = new LocalConnection();

        public FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path)
        {
            FileModel NewFile = new FileModel();

            using (SqlConnection connection = new SqlConnection(LocalDatabase.GetConnectionString()))
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

            using (SqlConnection connection = new SqlConnection(LocalDatabase.GetConnectionString()))
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
            using (SqlConnection connection = new SqlConnection(LocalDatabase.GetConnectionString()))
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
    }
}
