using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MDL
{
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
