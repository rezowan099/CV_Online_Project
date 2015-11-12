using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Language")]
        public string Name { get; set; }

        public virtual ICollection<LanguageProficiency> Language_Proficiency { get; set; }
    }
}