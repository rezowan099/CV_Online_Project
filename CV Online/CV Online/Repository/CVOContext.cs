using CV_Online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CV_Online.Repository
{
    public class CVOContext:DbContext 
    {
        public CVOContext() : base("name=DefaultConnection") { }

        public DbSet<ConcentrationMajorGroup> ConcentrationMajorGroups { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<ProfessionalQualification> ProfessionalQualifications { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<LanguageProficiency> LanguageProficiency { get; set; }
        public DbSet<Language> Languages { get; set; }
        //public DbSet<EducationInstitution> EducationInstitutions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        //public DbSet<EducationLevelMajorGroup> EducationalLevelMajorGroups { get; set; }        
        //public DbSet<RegisterExternalLoginModel> RegisterExternalLoginModels { get; set; }
        //public DbSet<LocalPasswordModel> LocalPasswordModels { get; set; }
        //public DbSet<LoginModel> LoginModels { get; set; }
        //public DbSet<RegisterModel> RegisterModels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConcentrationMajorGroup>()
                        .HasMany<EducationLevel>(c => c.EducationLevels)
                        .WithMany(e => e.ConcentrationMajorGroups)
                        .Map(ce =>
                        {
                            ce.MapLeftKey("EducationLevelId"); // For HasMany Table
                            ce.MapRightKey("ConcentrationMajorGroupId"); //For WithMany Table
                            ce.ToTable("ConcentrationMajorGroupEducationLevel");
                        });


            modelBuilder.Entity<Education>()
                                  .HasMany<Institution>(e => e.Institutions)
                                  .WithMany(i => i.Educations)
                                  .Map(ie =>
                                  {
                                      ie.MapLeftKey("InstitutionId"); // For HasMany Table
                                      ie.MapRightKey("EducationId"); //For WithMany Table
                                      ie.ToTable("EducationInstitution");
                                  });

        }


    }
}