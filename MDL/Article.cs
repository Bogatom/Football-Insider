using System;
using System.Collections.Generic;

namespace MDL
{
    public class Article
    {
        #region Properties
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public List<string> Image { get; set; }
        #endregion 
    }
}
