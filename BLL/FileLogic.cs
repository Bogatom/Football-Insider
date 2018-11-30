using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Interfaces_BLL_DAL;
using Interfaces_UI_BLL;
using MDL;

namespace BLL
{
    public class FileLogic : IFileLogic
    {
        IFileRepository _repo;

        public FileLogic(IFileRepository repo)
        {
            _repo = repo;
        }

        public FileModel AddFile(HttpPostedFileBase File, int ArticleID, string Path)
        {
            try
            {
                return _repo.AddFile(File, ArticleID, Path);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public FileModel DeleteFile(int ArticleID, int FileID)
        {
            try
            {
                return _repo.DeleteFile(ArticleID, FileID);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }

        public FileModel GetCurrentFile(int ArticleID, string File)
        {
            try
            {
                return _repo.GetCurrentFile(ArticleID, File);
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                throw;
            }
            catch (InvalidCastException invalidCastException)
            {
                Console.WriteLine(invalidCastException);
                throw;
            }
        }
    }
}
