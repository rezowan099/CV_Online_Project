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

            //_context.SaveChanges();

            //For Masters and Bachelor/Honours, no option will show for Diploma, Doctorate, Secondary and Higher Secondary
            //_context.Institutions.AddOrUpdate(
            //    i => i.Name,
            //    new Institution { Name = "University of Dhaka", Type = "Education" },
            //    new Institution { Name = "University of Rajshahi", Type = "Education" },
            //    new Institution { Name = "Bangladesh Agricultural University", Type = "Education" },
            //    new Institution { Name = "Bangladesh University of Engineering and Technology", Type = "Education" },
            //    new Institution { Name = "University of Chittagong", Type = "Education" },
            //    new Institution { Name = "Jahangirnagar University", Type = "Education" },
            //    new Institution { Name = "Islamic University, Bangladesh", Type = "Education" },
            //    new Institution { Name = "Khulna University", Type = "Education" },
            //    new Institution { Name = "Chittagong University of Engineering & Technology", Type = "Education" },
            //    new Institution { Name = "Bangladesh University of Textiles", Type = "Education" },
            //    new Institution { Name = "International Islamic University, Chittagong", Type = "Education" },
            //    new Institution { Name = "Ahsanullah University of Science and Technology", Type = "Education" },
            //    new Institution { Name = "American International University-Bangladesh", Type = "Education" },
            //    new Institution { Name = "BRAC University", Type = "Education" },
            //    new Institution { Name = "Daffodil International University ", Type = "Education" },
            //    new Institution { Name = "North South University", Type = "Education" },
            //    new Institution { Name = "East West University", Type = "Education" },
            //    new Institution { Name = "State University of Bangladesh", Type = "Education" },
            //    new Institution { Name = "United International University", Type = "Education" },
            //    new Institution { Name = "Adobe", Type = "Professional" },
            //    new Institution { Name = "Apple", Type = "Professional" },
            //    new Institution { Name = "Microsoft", Type = "Professional" },
            //    new Institution { Name = "Oracle", Type = "Professional" },
            //    new Institution { Name = "Linux Professional Institute", Type = "Professional" },
            //    new Institution { Name = "SAP Partner Academy", Type = "Professional" },
            //    new Institution { Name = "Cisco Systems", Type = "Professional" },
            //    new Institution { Name = "Other", Type = "Professional" }

            //    );

            //_context.Certifications.AddOrUpdate(
            //    c => c.Title,
            //    new Certification { Title = "Adobe Certified Expert (ACE)" },
            //    new Certification { Title = "Apple Certifications for IT Professionals" },
            //    new Certification { Title = "Linux Professional Institute Certified Level 1 (LPIC1)" },
            //    new Certification { Title = "Linux Professional Institute Certified Level 2 (LPIC2)" },
            //    new Certification { Title = "Linux Professional Institute Certified Level 3 (LPIC3)" },
            //    new Certification { Title = "Microsoft Certified Solutions Expert (MCSE)" },
            //    new Certification { Title = "Microsoft Certified Solutions Associate (MCSA)" },
            //    new Certification { Title = "Microsoft Specialist" },
            //    new Certification { Title = "SAP Certification" },
            //    new Certification { Title = "Cisco Certified Entry Networking Technician (CCENT)" },
            //    new Certification { Title = "Cisco Certified Network Associate (CCNA)" },
            //    new Certification { Title = "Other" }

            //    );

            ////For Masters and Bachelor/Honours, no option will show for Diploma, Doctorate, Secondary and Higher Secondary
            //var Institutions = new List<Institution>
            //{
            //    new Institution { Name = "University of Dhaka",  Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "University of Rajshahi", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Bangladesh Agricultural University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Bangladesh University of Engineering and Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "University of Chittagong", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Jahangirnagar University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Islamic University, Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Khulna University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Chittagong University of Engineering & Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Bangladesh University of Textiles", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "International Islamic University, Chittagong", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Ahsanullah University of Science and Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "American International University-Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "BRAC University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Daffodil International University ", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "North South University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "East West University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "State University of Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "United International University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Name = "Adobe", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Name = "Apple", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Name = "Microsoft", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Name = "Oracle", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Name = "Linux Professional Institute", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Name = "SAP Partner Academy", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Name = "Cisco Systems", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },

            //};

            //Institutions.ForEach(t => _context.Institutions.AddOrUpdate(t));
            ////_context.SaveChanges();

            //var Certifications = new List<Certification>
            //{
            //    new Certification { Title = "Adobe Certified Expert (ACE)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 20) },
            //    new Certification { Title = "Apple Certifications for IT Professionals", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 21)  },
            //    new Certification { Title = "Linux Professional Institute Certified Level 1 (LPIC1)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 24)  },
            //    new Certification { Title = "Linux Professional Institute Certified Level 2 (LPIC2)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 24)  },
            //    new Certification { Title = "Linux Professional Institute Certified Level 3 (LPIC3)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 24)  },
            //    new Certification { Title = "Microsoft Certified Solutions Expert (MCSE)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
            //    new Certification { Title = "Microsoft Certified Solutions Associate (MCSA)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
            //    new Certification { Title = "Microsoft Specialist", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
            //    new Certification { Title = "SAP Certification", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 25)  },
            //    new Certification { Title = "Cisco Certified Entry Networking Technician (CCENT)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 26)  },
            //    new Certification { Title = "Cisco Certified Network Associate (CCNA)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 26)  },
            //};

            //Certifications.ForEach(t => _context.Certifications.AddOrUpdate(t));
            //_context.SaveChanges();

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


            //var Institutions = new List<Institution>
            //{
            //    new Institution { Id=1, Name = "University of Dhaka",  Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=2, Name = "University of Rajshahi", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=3, Name = "Bangladesh Agricultural University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=4, Name = "Bangladesh University of Engineering and Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=5, Name = "University of Chittagong", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=6, Name = "Jahangirnagar University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=7, Name = "Islamic University, Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=8, Name = "Khulna University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=9, Name = "Chittagong University of Engineering & Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=10, Name = "Bangladesh University of Textiles", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=11, Name = "International Islamic University, Chittagong", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=12, Name = "Ahsanullah University of Science and Technology", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=13, Name = "American International University-Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=14, Name = "BRAC University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=15, Name = "Daffodil International University ", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=16, Name = "North South University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=17, Name = "East West University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=18, Name = "State University of Bangladesh", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=19, Name = "United International University", Other = String.Empty, Type = "Education", Certifications = new List<Certification>() },
            //    new Institution { Id=20, Name = "Adobe", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Id=21, Name = "Apple", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Id=22, Name = "Microsoft", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Id=23, Name = "Oracle", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Id=24, Name = "Linux Professional Institute", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Id=25, Name = "SAP Partner Academy", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },
            //    new Institution { Id=26, Name = "Cisco Systems", Other = String.Empty, Type = "Professional", Certifications = new List<Certification>() },

            //};

            //Institutions.ForEach(t => _context.Institutions.AddOrUpdate(t));
            ////_context.SaveChanges();

            //var Certifications = new List<Certification>
            //{
            //    new Certification { Id=1, Title = "Adobe Certified Expert (ACE)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 20) },
            //    new Certification { Id=2, Title = "Apple Certifications for IT Professionals", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 21)  },
            //    new Certification { Id=3, Title = "Linux Professional Institute Certified Level 1 (LPIC1)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 24)  },
            //    new Certification { Id=4, Title = "Linux Professional Institute Certified Level 2 (LPIC2)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 24)  },
            //    new Certification { Id=5, Title = "Linux Professional Institute Certified Level 3 (LPIC3)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 24)  },
            //    new Certification { Id=6, Title = "Microsoft Certified Solutions Expert (MCSE)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
            //    new Certification { Id=7, Title = "Microsoft Certified Solutions Associate (MCSA)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
            //    new Certification { Id=8, Title = "Microsoft Specialist", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 22)  },
            //    new Certification { Id=9, Title = "SAP Certification", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 25)  },
            //    new Certification { Id=10, Title = "Cisco Certified Entry Networking Technician (CCENT)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 26)  },
            //    new Certification { Id=11, Title = "Cisco Certified Network Associate (CCNA)", Other = String.Empty, Institution = Institutions.FirstOrDefault(i => i.Id == 26)  },
            //};


        }
    }
}
