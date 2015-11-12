using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class EmploymentHistory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string CompanyBusiness { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string CompanyLocation { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string PositionHeld { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Responsibilities { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string From { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string To { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }      
    }
}