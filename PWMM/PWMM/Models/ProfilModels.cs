using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PWMM.Models
{
    public class UploadFileModel
    {
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Pod tytuł ")]
        public string Title2 { get; set; }

        [Required]
        [Display(Name = "Zdjęcie")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Źródło")]
        public string Source { get; set; }
    }
}