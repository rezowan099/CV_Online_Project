using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "* Required")]
        public string LastName { get; set; }

        [DisplayName("Father's Name")]
        [Required(ErrorMessage = "* Required")]
        public string FathersName { get; set; }

        [DisplayName("Mother's Name")]
        [Required(ErrorMessage = "* Required")]
        public string MothersName { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "* Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "* Required")]
        public string Nationality { get; set; }

        [DisplayName("National Id No")]
        [Required(ErrorMessage = "* Required")]
        public string NationalIdNo { get; set; }

        [DisplayName("Present Address")]
        [Required(ErrorMessage = "* Required")]
        public string PresentAddress { get; set; }

        [DisplayName("Permanent Address")]
        [Required(ErrorMessage = "* Required")]
        public string PermanentAddress { get; set; }

        [DisplayName("Current Location")]
        [Required(ErrorMessage = "* Required")]
        public string CurrentLocation { get; set; }

        [DisplayName("Mobile Phone")]
        [Required(ErrorMessage = "* Required")]
        public string MobilePhone { get; set; }

        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }

        [DisplayName("Office Phone")]
        public string OfficePhone { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "* Required")]
        public string Email { get; set; }

        [DisplayName("Alternate Email")]
        public string AlternateEmail { get; set; }

        [DisplayName("Present Salary")]
        public double? PresentSalary { get; set; }

        [DisplayName("Expected Salary")]
        public double? ExpectedSalary { get; set; }

        public string Photo { get; set; }

        [DisplayName("Career Objective")]
        [Required(ErrorMessage = "* Required")]
        [StringLength(100, ErrorMessage = "* You can write Maximum 100 character.")]
        public string CareerObjective { get; set; }

        [DisplayName("Career Summary")]
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
        public virtual UserProfileModel UserProfile { get; set; }

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

            //if (ExpectedSalary < 0)
            //{
            //    yield return new ValidationResult("Expected Salary cannot be negative!");
            //}

        }

       

    }
}