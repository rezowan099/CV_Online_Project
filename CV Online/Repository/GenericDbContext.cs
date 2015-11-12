using CV_Online.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CV_Online.Repository
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext() : base("DefaultConnection") { }

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
        public DbSet<UserProfileModel> UserProfiles { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<EducationLevel>()
                            .HasMany(e => e.ConcentrationMajorGroups)
                            .WithMany(c => c.EducationLevels)
                            .Map(ec =>
                            {
                                ec.ToTable("EducationLevelConcentrationMajorGroup");
                                ec.MapLeftKey("EducationLevelId");
                                ec.MapRightKey("ConcentrationMajorGroupId");
                            });

            modelBuilder.Entity<Certification>()
                .HasRequired(c => c.Institution)
                .WithMany(i => i.Certifications)
                .HasForeignKey(c => c.InstitutionId);

        }
    }
}