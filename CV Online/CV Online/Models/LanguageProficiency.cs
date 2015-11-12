using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class LanguageProficiency
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Reading { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Writing { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Speaking { get; set; }

        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        [Display(Name = "Language")]
        public virtual Language Language { get; set; }
    }
}