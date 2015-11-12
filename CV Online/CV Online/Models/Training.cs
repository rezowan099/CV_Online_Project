using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string TrainingTitle { get; set; }

        public string TopicsCovered { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Institute { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Country { get; set; }

        public string Location { get; set; }

        [Required(ErrorMessage = "* Required")]
        public int? TrainingCompletionYear { get; set; }

        public int? Duration { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; } 
         
    }
}