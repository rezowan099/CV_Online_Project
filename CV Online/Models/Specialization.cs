using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayName("Fields Of Specialization")]
        public string FieldsOfSpecialization { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Description { get; set; }

        [DisplayName("Extracurricular Activities")]
        public string ExtracurricularActivities { get; set; }

        public int PersonalInfoId { get; set; }

        [ForeignKey("PersonalInfoId")]
        public virtual PersonalInformation PersonalInformation { get; set; }

        public virtual ICollection<LanguageProficiency> LanguageProficiencies { get; set; } 
    }
}