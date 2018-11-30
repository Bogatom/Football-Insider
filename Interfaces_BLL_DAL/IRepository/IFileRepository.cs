using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaces_BLL_DAL
{
    public interface IFileRepository
    {
        FileModel AddFile(HttpPostedFileBase File, int ArticleID, string Path);
        FileModel DeleteFile(int ArticleID, int FileID);
        FileModel GetCurrentFile(int ArticleID, string File);
    }
}
