using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class ProfessionalQualification
    {
        [Key]
        public int Id { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime To { get; set; }

        public int CertificationId { get; set; }

        [ForeignKey("CertificationId")]
        public virtual Certification Certification { get; set; }

        public int InstitutionId { get; set; }

        [ForeignKey("InstitutionId")]
        public virtual Institution Institution { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }    
    }
}