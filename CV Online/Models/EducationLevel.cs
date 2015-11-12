using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class EducationLevel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Level { get; set; }

        public virtual ICollection<ConcentrationMajorGroup> ConcentrationMajorGroups { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }

}