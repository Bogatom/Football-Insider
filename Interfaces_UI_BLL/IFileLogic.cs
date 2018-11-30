using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interfaces_UI_BLL
{
    public interface IFileLogic
    {
        FileModel AddFile(HttpPostedFileBase file, int ArticleId, string Path);
        FileModel DeleteFile(int ArticleID, int FileID);
        FileModel GetCurrentFile(int ArticleID, string File);
    }
}
