using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Online.Models
{
    public class EmploymentHistory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayName("Company Business")]
        public string CompanyBusiness { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayName("Company Location")]
        public string CompanyLocation { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayName("Position Held")]
        public string PositionHeld { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Responsibilities { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }

        //[RequiredIf("IsContinue", false)]
        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? To { get; set; }

        //[NotMapped]
        [Required(ErrorMessage = "* Required")]
        [DisplayName("To Present")]
        public bool IsContinue { set; get; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }     



    }
}