using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Exam/Degree Title")]
        [Required(ErrorMessage = "* Required")]
        public string ExamDegreeTitle { get; set; }

        
        [Required(ErrorMessage = "* Required")]
        public int Result { get; set; }

        [Required(ErrorMessage = "* Required")]
        public int Scale { get; set; }

        [DisplayName("Year of Passing")]
        [Required(ErrorMessage = "* Required")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid Year")]
        public int  YearOfPassing { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string  Duration { get; set; }

        public string Location { get; set; }

        public string Achievement { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }

        [DisplayName("Concentration/Major/Group")]
        public int ConcentrationMajorGroupId { get; set; }

        [ForeignKey("ConcentrationMajorGroupId")]
        public virtual ConcentrationMajorGroup ConcentrationMajorGroup { get; set; }

        public int InstitutionId { get; set; }

        [ForeignKey("InstitutionId")]
        public virtual Institution Institution { get; set; }
        
        public int EducationLevelId { get; set; }

        [ForeignKey("EducationLevelId")]
        public virtual EducationLevel EducationLevel { get; set; }

    }
}