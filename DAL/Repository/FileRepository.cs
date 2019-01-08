using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Interfaces_BLL_DAL;
using MDL;

namespace DAL
{
    public class FileRepository : IFileRepository
    {
        IFileContext _context;

        public FileRepository(IFileContext context)
        {
            _context = context;
        }

        public FileModel AddFile(HttpPostedFileBase File, int ArticleID, string Path)
        {
            try
            {
                return _context.AddFile(File, ArticleID, Path);
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
                return _context.DeleteFile(ArticleID, FileID);
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
                return _context.GetCurrentFile(ArticleID, File);
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

        public List<FileModel> GetAllFiles()
        {
            try
            {
                return _context.GetAllFiles();
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
