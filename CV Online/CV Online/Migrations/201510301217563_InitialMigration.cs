namespace CV_Online.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Other = c.String(),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId, cascadeDelete: true)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Other = c.String(),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamDegreeTitle = c.String(nullable: false),
                        Result = c.Int(nullable: false),
                        Scale = c.String(nullable: false),
                        YearOfPassing = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Achievement = c.String(),
                        PersonalInfoId = c.Int(nullable: false),
                        ConcentrationMajorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConcentrationMajorGroups", t => t.ConcentrationMajorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalInformations", t => t.PersonalInfoId, cascadeDelete: true)
                .Index(t => t.PersonalInfoId)
                .Index(t => t.ConcentrationMajorGroupId);
            
            CreateTable(
                "dbo.ConcentrationMajorGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EducationLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FathersName = c.String(nullable: false),
                        MothersName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(nullable: false),
                        NationalIdNo = c.String(nullable: false),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        CurrentLocation = c.String(nullable: false),
                        MobilePhone = c.String(nullable: false),
                        HomePhone = c.String(),
                        OfficePhone = c.String(),
                        Email = c.String(nullable: false),
                        AlternateEmail = c.String(),
                        PresentSalary = c.Double(),
                        ExpectedSalary = c.Double(),
                        Photo = c.Byte(nullable: false),
                        CareerObjective = c.String(nullable: false, maxLength: 100),
                        CareerSummary = c.String(nullable: false, maxLength: 100),
                        GenderId = c.Int(nullable: false),
                        MaritalStatusId = c.Int(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.MaritalStatus", t => t.MaritalStatusId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.MaritalStatusId)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.EmploymentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        CompanyBusiness = c.String(nullable: false),
                        CompanyLocation = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        PositionHeld = c.String(nullable: false),
                        Responsibilities = c.String(nullable: false),
                        From = c.String(nullable: false),
                        To = c.String(nullable: false),
                        PersonalInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInformations", t => t.PersonalInfoId, cascadeDelete: true)
                .Index(t => t.PersonalInfoId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessionalQualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Institute = c.String(nullable: false),
                        Location = c.String(),
                        From = c.String(nullable: false),
                        To = c.String(nullable: false),
                        CertificationId = c.Int(nullable: false),
                        PersonalInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certifications", t => t.CertificationId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalInformations", t => t.PersonalInfoId, cascadeDelete: true)
                .Index(t => t.CertificationId)
                .Index(t => t.PersonalInfoId);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Organization = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        Relation = c.String(nullable: false),
                        PhoneOffice = c.String(),
                        PhoneResidence = c.String(),
                        Mobile = c.String(),
                        PersonalInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInformations", t => t.PersonalInfoId, cascadeDelete: true)
                .Index(t => t.PersonalInfoId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldsOfSpecialization = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ExtracurricularActivities = c.String(),
                        PersonalInfoId = c.Int(nullable: false),
                        LanguageProficiencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LanguageProficiencies", t => t.LanguageProficiencyId, cascadeDelete: true)
                .ForeignKey("dbo.PersonalInformations", t => t.PersonalInfoId, cascadeDelete: true)
                .Index(t => t.PersonalInfoId)
                .Index(t => t.LanguageProficiencyId);
            
            CreateTable(
                "dbo.LanguageProficiencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reading = c.String(nullable: false),
                        Writing = c.String(nullable: false),
                        Speaking = c.String(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainingTitle = c.String(nullable: false),
                        TopicsCovered = c.String(),
                        Institute = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Location = c.String(),
                        TrainingCompletionYear = c.Int(nullable: false),
                        Duration = c.Int(),
                        PersonalInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalInformations", t => t.PersonalInfoId, cascadeDelete: true)
                .Index(t => t.PersonalInfoId);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ConcentrationMajorGroupEducationLevel",
                c => new
                    {
                        EducationLevelId = c.Int(nullable: false),
                        ConcentrationMajorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EducationLevelId, t.ConcentrationMajorGroupId })
                .ForeignKey("dbo.ConcentrationMajorGroups", t => t.EducationLevelId, cascadeDelete: true)
                .ForeignKey("dbo.EducationLevels", t => t.ConcentrationMajorGroupId, cascadeDelete: true)
                .Index(t => t.EducationLevelId)
                .Index(t => t.ConcentrationMajorGroupId);
            
            CreateTable(
                "dbo.EducationInstitution",
                c => new
                    {
                        InstitutionId = c.Int(nullable: false),
                        EducationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstitutionId, t.EducationId })
                .ForeignKey("dbo.Educations", t => t.InstitutionId, cascadeDelete: true)
                .ForeignKey("dbo.Institutions", t => t.EducationId, cascadeDelete: true)
                .Index(t => t.InstitutionId)
                .Index(t => t.EducationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonalInformations", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Trainings", "PersonalInfoId", "dbo.PersonalInformations");
            DropForeignKey("dbo.Specializations", "PersonalInfoId", "dbo.PersonalInformations");
            DropForeignKey("dbo.Specializations", "LanguageProficiencyId", "dbo.LanguageProficiencies");
            DropForeignKey("dbo.LanguageProficiencies", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.References", "PersonalInfoId", "dbo.PersonalInformations");
            DropForeignKey("dbo.ProfessionalQualifications", "PersonalInfoId", "dbo.PersonalInformations");
            DropForeignKey("dbo.ProfessionalQualifications", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.PersonalInformations", "MaritalStatusId", "dbo.MaritalStatus");
            DropForeignKey("dbo.PersonalInformations", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.EmploymentHistories", "PersonalInfoId", "dbo.PersonalInformations");
            DropForeignKey("dbo.Educations", "PersonalInfoId", "dbo.PersonalInformations");
            DropForeignKey("dbo.EducationInstitution", "EducationId", "dbo.Institutions");
            DropForeignKey("dbo.EducationInstitution", "InstitutionId", "dbo.Educations");
            DropForeignKey("dbo.Educations", "ConcentrationMajorGroupId", "dbo.ConcentrationMajorGroups");
            DropForeignKey("dbo.ConcentrationMajorGroupEducationLevel", "ConcentrationMajorGroupId", "dbo.EducationLevels");
            DropForeignKey("dbo.ConcentrationMajorGroupEducationLevel", "EducationLevelId", "dbo.ConcentrationMajorGroups");
            DropForeignKey("dbo.Certifications", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.EducationInstitution", new[] { "EducationId" });
            DropIndex("dbo.EducationInstitution", new[] { "InstitutionId" });
            DropIndex("dbo.ConcentrationMajorGroupEducationLevel", new[] { "ConcentrationMajorGroupId" });
            DropIndex("dbo.ConcentrationMajorGroupEducationLevel", new[] { "EducationLevelId" });
            DropIndex("dbo.Trainings", new[] { "PersonalInfoId" });
            DropIndex("dbo.LanguageProficiencies", new[] { "LanguageId" });
            DropIndex("dbo.Specializations", new[] { "LanguageProficiencyId" });
            DropIndex("dbo.Specializations", new[] { "PersonalInfoId" });
            DropIndex("dbo.References", new[] { "PersonalInfoId" });
            DropIndex("dbo.ProfessionalQualifications", new[] { "PersonalInfoId" });
            DropIndex("dbo.ProfessionalQualifications", new[] { "CertificationId" });
            DropIndex("dbo.EmploymentHistories", new[] { "PersonalInfoId" });
            DropIndex("dbo.PersonalInformations", new[] { "UserProfileId" });
            DropIndex("dbo.PersonalInformations", new[] { "MaritalStatusId" });
            DropIndex("dbo.PersonalInformations", new[] { "GenderId" });
            DropIndex("dbo.Educations", new[] { "ConcentrationMajorGroupId" });
            DropIndex("dbo.Educations", new[] { "PersonalInfoId" });
            DropIndex("dbo.Certifications", new[] { "InstitutionId" });
            DropTable("dbo.EducationInstitution");
            DropTable("dbo.ConcentrationMajorGroupEducationLevel");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Trainings");
            DropTable("dbo.Languages");
            DropTable("dbo.LanguageProficiencies");
            DropTable("dbo.Specializations");
            DropTable("dbo.References");
            DropTable("dbo.ProfessionalQualifications");
            DropTable("dbo.MaritalStatus");
            DropTable("dbo.Genders");
            DropTable("dbo.EmploymentHistories");
            DropTable("dbo.PersonalInformations");
            DropTable("dbo.EducationLevels");
            DropTable("dbo.ConcentrationMajorGroups");
            DropTable("dbo.Educations");
            DropTable("dbo.Institutions");
            DropTable("dbo.Certifications");
        }
    }
}
