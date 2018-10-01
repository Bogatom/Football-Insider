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
        public Image _Image { get; set; }
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

    public class Image
    {
        public int ArticleId { get; set; }
        public int ImageID { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Selecteer een bestand.")]
        [Display(Name = "Selecteer een bestand(en)")]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
