using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class PersonalInformation:IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string FathersName { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string MothersName { get; set; }

        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "* Required")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string NationalIdNo { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string PresentAddress { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string PermanentAddress { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string CurrentLocation { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string OfficePhone { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Email { get; set; }

        public string AlternateEmail { get; set; }    

        public double? PresentSalary { get; set; }

        public double? ExpectedSalary { get; set; }

        [Required(ErrorMessage = "* Required")]
        public byte Photo { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "* You can write Maximum 100 character.")]
        public string CareerObjective { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "* You can write Maximum 100 character.")]
        public string CareerSummary { get; set; }


        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        public int MaritalStatusId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public virtual MaritalStatus MaritalStatus { get; set; }

        public int UserProfileId { get; set; }

        [ForeignKey("UserProfileId")]
        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; }

        public virtual ICollection<Training> Trainings { get; set; }

        public virtual ICollection<Reference> References { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

        public virtual ICollection<ProfessionalQualification> ProfessionalQualifications { get; set; }

        public virtual ICollection<Specialization> Specializations { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PresentSalary < 0)
            {
                yield return new ValidationResult("Present Salary cannot be negative!");
            } 
        }


    }
}