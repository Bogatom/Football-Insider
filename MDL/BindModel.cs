using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MDL
{
    public class BindModel
    {
        public Article _Article { get; set; }
        public Category _Category { get; set; }
        public FileModel _File { get; set; }
    }

    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public List<string> Image { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class FileModel
    {
        public int ArticleId { get; set; }
        public int FileId { get; set; }
        public string FilePath { get; set; }

        [Required(ErrorMessage = "Selecteer een bestand.")]
        [Display(Name = "Selecteer een bestand(en)")]
        public HttpPostedFileBase[] Files { get; set; }

    }
}
