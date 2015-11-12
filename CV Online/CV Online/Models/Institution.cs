using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV_Online.Models
{
    public class Institution
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        public string Other { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string Type { get; set; }

        public virtual ICollection<Certification> Certifications { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

        
    }
}