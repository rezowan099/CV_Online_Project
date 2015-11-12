using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class Reference
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Organization { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Designation { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Relation { get; set; }

        public string PhoneOffice { get; set; }

        public string PhoneResidence { get; set; }
        
        public string Mobile { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }        
    }
}