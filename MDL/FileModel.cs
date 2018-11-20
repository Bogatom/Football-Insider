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
        public int Article_ID { get; set; }
        public int File_ID { get; set; }
        public string FilePath { get; set; }

        [Required(ErrorMessage = "Selecteer een bestand.")]
        [Display(Name = "Selecteer een bestand(en)")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}
