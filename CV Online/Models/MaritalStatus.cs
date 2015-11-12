using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class MaritalStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual ICollection<PersonalInformation> PersonalInformations { get; set; }
    }
}