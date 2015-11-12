using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class EducationInstitution
    {
        [Key]
        public int Id { get; set; }

        public int EducationId { get; set; }

        [ForeignKey("EducationId")]
        public Education Education { get; set; }

        public int InstitutionId { get; set; }

        [ForeignKey("InstitutionId")]
        public virtual Institution Institution { get; set; }

    }
}