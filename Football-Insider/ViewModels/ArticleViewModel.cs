using MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Football_Insider.ViewModels
{
    public class ArticleViewModel
    {
        public List<Article> Articles { get; set; }
        public Article Article { get; set; }
    }
}