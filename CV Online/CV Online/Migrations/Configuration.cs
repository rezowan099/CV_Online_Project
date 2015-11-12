namespace CV_Online.Migrations
{
    using CV_Online.Models;
    using CV_Online.Repository;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                new UserProfile { UserName = "Admin" },
                new UserProfile { UserName = "Suvro" }
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


            _context.EducationLevels.AddOrUpdate(
                e => e.Level,
                new EducationLevel { Level = "Secondary" },
                new EducationLevel { Level = "Higher Secondary" },
                new EducationLevel { Level = "Diploma" },
                new EducationLevel { Level = "Bachelor/Honours" },
                new EducationLevel { Level = "Masters" },
                new EducationLevel { Level = "Doctorate" }

                );

        
            _context.ConcentrationMajorGroups.AddOrUpdate(
              new ConcentrationMajorGroup { Type = "Science" },
              new ConcentrationMajorGroup { Type = "Commerce"},
              new ConcentrationMajorGroup { Type = "Computer Science and Engineering"},
              new ConcentrationMajorGroup { Type = "Civil Engineering"},
              new ConcentrationMajorGroup { Type = "Architecture" },
              new ConcentrationMajorGroup { Type = "Electrical Engineering" },
              new ConcentrationMajorGroup { Type = "Management" },
              new ConcentrationMajorGroup { Type = "Business Administration" },
              new ConcentrationMajorGroup { Type = "Pharmacy" },
              new ConcentrationMajorGroup { Type = "Software Engineering" },
              new ConcentrationMajorGroup { Type = "Art" },
              new ConcentrationMajorGroup { Type = "English" },
              new ConcentrationMajorGroup { Type = "Telecommunication" },
              new ConcentrationMajorGroup { Type = "Physics" },
              new ConcentrationMajorGroup { Type = "Network and Communications Management"},
              new ConcentrationMajorGroup { Type = "Art" },
              new ConcentrationMajorGroup { Type = "English" },
              new ConcentrationMajorGroup { Type = "Telecommunications Technology" },
              new ConcentrationMajorGroup { Type = "Textile Engineering‎", Other = String.Empty }
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



            base.Seed(_context);
            _context.SaveChanges();



        }
    }
}
