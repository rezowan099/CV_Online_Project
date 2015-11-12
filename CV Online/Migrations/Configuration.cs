namespace CV_Online.Migrations
{
    using CV_Online.Models;
    using CV_Online.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<CV_Online.Repository.CVOContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CV_Online.Repository.CVOContext context)
        {
            CVOContext _context = new CVOContext();

            _context.Languages.AddOrUpdate(
                l => l.Name,
                new Language { Name = "Bangla" },
                new Language { Name = "English" },
                new Language { Name = "Arabic" },
                new Language { Name = "German" },
                new Language { Name = "Hindi" }
                );

            _context.UserProfiles.AddOrUpdate(
                u => u.UserName,
                new UserProfileModel { UserName = "Admin" },
                new UserProfileModel { UserName = "Suvro" }
                );

            _context.Genders.AddOrUpdate(
                g => g.Type,
                new Gender { Type = "Male" },
                new Gender { Type = "Female" }
                );

            _context.MaritalStatus.AddOrUpdate(
                m => m.Status,
                new MaritalStatus { Status = "Single" },
                new MaritalStatus { Status = "Married" },
                new MaritalStatus { Status = "Divorced" },
                new MaritalStatus { Status = "Widowed" }

                );           

            //For Masters and Bachelor/Honours, no option will show for Diploma, Doctorate, Secondary and Higher Secondary
            var Institutions = new List<Institution>
            {

                new Institution { Id=1, Name = "University of Dhaka",  Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=2, Name = "University of Rajshahi", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=3, Name = "Bangladesh Agricultural University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=4, Name = "Bangladesh University of Engineering and Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=5, Name = "University of Chittagong", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=6, Name = "Jahangirnagar University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=7, Name = "Islamic University, Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=8, Name = "Khulna University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=9, Name = "Chittagong University of Engineering & Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=10, Name = "Bangladesh University of Textiles", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=11, Name = "International Islamic University, Chittagong", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=12, Name = "Ahsanullah University of Science and Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=13, Name = "American International University-Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=14, Name = "BRAC University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=15, Name = "Daffodil International University ", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=16, Name = "North South University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=17, Name = "East West University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=18, Name = "State University of Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=19, Name = "United International University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=20, Name = "Adobe", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
                new Institution { Id=21, Name = "Apple", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
                new Institution { Id=22, Name = "Microsoft", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
                new Institution { Id=23, Name = "Linux Professional Institute", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
                new Institution { Id=24, Name = "SAP Partner Academy", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
                new Institution { Id=25, Name = "Cisco Systems", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
                
                new Institution { Id=26, Name = "Viquarunnisa Noon School & College", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=27, Name = "Cantonment Public School & College", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=28, Name = "Oxford International School", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=29, Name = "Notre Dame College", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
                new Institution { Id=30, Name = "Government Laboratory High School", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },

            };

            Institutions.ForEach(t => _context.Institutions.AddOrUpdate(t));
            //_context.SaveChanges();

            var Certifications = new List<Certification>
            {
                new Certification { Id=1, Title = "Adobe Certified Expert (ACE)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 20) },
                new Certification { Id=2, Title = "Apple Certifications for IT Professionals", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 21)  },
                new Certification { Id=3, Title = "Microsoft Certified Solutions Expert (MCSE)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
                new Certification { Id=4, Title = "Microsoft Certified Solutions Associate (MCSA)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
                new Certification { Id=5, Title = "Microsoft Specialist", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
                new Certification { Id=6, Title = "Linux Professional Institute Certified Level 1 (LPIC1)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 23)  },
                new Certification { Id=7, Title = "Linux Professional Institute Certified Level 2 (LPIC2)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 23)  },
                new Certification { Id=8, Title = "Linux Professional Institute Certified Level 3 (LPIC3)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 23)  },
                new Certification { Id=9, Title = "SAP Certification", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 24)  },
                new Certification { Id=10, Title = "Cisco Certified Entry Networking Technician (CCENT)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 25)  },
                new Certification { Id=11, Title = "Cisco Certified Network Associate (CCNA)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 25)  },
            };


            
            Institutions[19].Certifications.Add(Certifications[0]);
            Institutions[20].Certifications.Add(Certifications[1]);
            Institutions[21].Certifications.Add(Certifications[2]);
            Institutions[21].Certifications.Add(Certifications[3]);
            Institutions[21].Certifications.Add(Certifications[4]);
            Institutions[22].Certifications.Add(Certifications[5]);
            Institutions[22].Certifications.Add(Certifications[6]);
            Institutions[22].Certifications.Add(Certifications[7]);
            Institutions[23].Certifications.Add(Certifications[8]);
            Institutions[24].Certifications.Add(Certifications[9]);
            Institutions[24].Certifications.Add(Certifications[10]);

            _context.SaveChanges();

            var EducationLevel1 = new EducationLevel { Level = "Secondary", ConcentrationMajorGroups = new List<ConcentrationMajorGroup>() };
            var EducationLevel2 = new EducationLevel { Level = "Higher Secondary", ConcentrationMajorGroups = new List<ConcentrationMajorGroup>() };
            var EducationLevel3 = new EducationLevel { Level = "Diploma", ConcentrationMajorGroups = new List<ConcentrationMajorGroup>() };
            var EducationLevel4 = new EducationLevel { Level = "Bachelor/Honours", ConcentrationMajorGroups = new List<ConcentrationMajorGroup>() };
            var EducationLevel5 = new EducationLevel { Level = "Masters", ConcentrationMajorGroups = new List<ConcentrationMajorGroup>() };
            var EducationLevel6 = new EducationLevel { Level = "Doctorate", ConcentrationMajorGroups = new List<ConcentrationMajorGroup>() };

            //For Secondary, Higher Secondary, Masters and Bachelor/Honours. Others will remain without any option
            var ConcentrationMajorGroup1 = new ConcentrationMajorGroup { Type = "Science", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup2 = new ConcentrationMajorGroup { Type = "Commerce", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup3 = new ConcentrationMajorGroup { Type = "Computer Science and Engineering", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup4 = new ConcentrationMajorGroup { Type = "Civil Engineering", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup5 = new ConcentrationMajorGroup { Type = "Architecture", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup6 = new ConcentrationMajorGroup { Type = "Electrical Engineering", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup7 = new ConcentrationMajorGroup { Type = "Management", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup8 = new ConcentrationMajorGroup { Type = "Textile Engineering", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup9 = new ConcentrationMajorGroup { Type = "Business Administration", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup10 = new ConcentrationMajorGroup { Type = "Pharmacy", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup11 = new ConcentrationMajorGroup { Type = "Software Engineering", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup12 = new ConcentrationMajorGroup { Type = "Art", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup13 = new ConcentrationMajorGroup { Type = "English", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup14 = new ConcentrationMajorGroup { Type = "Telecommunication", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup15 = new ConcentrationMajorGroup { Type = "Physics", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup16 = new ConcentrationMajorGroup { Type = "Network and Communications Management", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup17 = new ConcentrationMajorGroup { Type = "Art", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup18 = new ConcentrationMajorGroup { Type = "English", EducationLevels = new List<EducationLevel>() };
            var ConcentrationMajorGroup19 = new ConcentrationMajorGroup { Type = "Telecommunications Technology", EducationLevels = new List<EducationLevel>() };



            EducationLevel1.ConcentrationMajorGroups.Add(ConcentrationMajorGroup1);
            EducationLevel1.ConcentrationMajorGroups.Add(ConcentrationMajorGroup2);

            EducationLevel2.ConcentrationMajorGroups.Add(ConcentrationMajorGroup1);
            EducationLevel2.ConcentrationMajorGroups.Add(ConcentrationMajorGroup2);

            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup3);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup4);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup5);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup6);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup7);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup8);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup9);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup10);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup11);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup12);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup13);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup14);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup15);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup16);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup17);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup18);
            EducationLevel4.ConcentrationMajorGroups.Add(ConcentrationMajorGroup19);

            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup3);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup4);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup5);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup6);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup7);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup8);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup9);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup10);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup11);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup12);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup13);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup14);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup15);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup16);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup17);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup18);
            EducationLevel5.ConcentrationMajorGroups.Add(ConcentrationMajorGroup19);




            _context.EducationLevels.AddOrUpdate(EducationLevel1);
            _context.EducationLevels.AddOrUpdate(EducationLevel2);
            _context.EducationLevels.AddOrUpdate(EducationLevel3);
            _context.EducationLevels.AddOrUpdate(EducationLevel4);
            _context.EducationLevels.AddOrUpdate(EducationLevel5);
            _context.EducationLevels.AddOrUpdate(EducationLevel6);

       
            base.Seed(_context);
            _context.SaveChanges();

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection(
                 connectionStringName: "DefaultConnection",
                 userTableName: "UserProfile",
                 userIdColumn: "UserID",
                 userNameColumn: "UserName",
                 autoCreateTables: true);

            var role = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!role.RoleExists("Admin"))
            {
                role.CreateRole("Admin");
            }

            if (!role.RoleExists("Operator"))
            {
                role.CreateRole("Operator");
            }

            if (membership.GetUser("Suvro", false) == null)
            {
                membership.CreateUserAndAccount("Suvro", "leads@123");
            }

            if (membership.GetUser("Admin", false) == null)
            {
                membership.CreateUserAndAccount("Admin", "leads@123");
            }

            if (!role.GetRolesForUser("Admin").Contains("Admin"))
            {
                role.AddUsersToRoles(new[] { "Admin" }, new[] { "Admin" });
            }

            if (!role.GetRolesForUser("Suvro").Contains("Operator"))
            {
                role.AddUsersToRoles(new[] { "Suvro" }, new[] { "Operator" });
            }
        }
    }
}
