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

    
}
