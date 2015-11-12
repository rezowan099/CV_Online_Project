using System;
using System.Collections.Generic;
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

        [Required(ErrorMessage = "* Required")]
        public string Institute { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string From { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string To { get; set; }

        public int CertificationId { get; set; }

        [ForeignKey("CertificationId")]
        public Certification Certification { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }    
    }
}