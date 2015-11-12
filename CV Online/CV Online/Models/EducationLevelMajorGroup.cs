using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class EducationLevelMajorGroup
    {
        [Key]
        public int Id { get; set; }

        public int EducationLevelId { get; set; }

        [ForeignKey("EducationLevelId")]
        public virtual EducationLevel EducationLevel { get; set; }

        public int ConcentrationMajorGroupId { get; set; }

        [ForeignKey("ConcentrationMajorGroupId")]
        public virtual ConcentrationMajorGroup ConcentrationMajorGroup { get; set; }


    }
}