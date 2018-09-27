using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDL
{
    public class Article
    {
        #region Properties
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Voer een titel in.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Voer een categorie in.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Voeg een beschrijving toe.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Voeg een afbeelding(en) toe.")]
        public List<string> Image { get; set; }
        #endregion 
    }
}
