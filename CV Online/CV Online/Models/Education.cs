using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "* Required")]
        public string ExamDegreeTitle { get; set; }

        [Required(ErrorMessage = "* Required")]
        public int Result { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Scale { get; set; }

        [Required(ErrorMessage = "* Required")]
        public int  YearOfPassing { get; set; }

        [Required(ErrorMessage = "* Required")]
        public int  Duration { get; set; }

        public string Achievement { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }


        public int ConcentrationMajorGroupId { get; set; }

        [ForeignKey("ConcentrationMajorGroupId")]
        public virtual ConcentrationMajorGroup ConcentrationMajorGroup { get; set; }

        public virtual ICollection<Institution> Institutions { get; set; }


    }
}