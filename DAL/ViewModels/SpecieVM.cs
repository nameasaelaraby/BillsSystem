using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class SpecieVM
    {
        public int SpecieId { get; set; }

        public Specie specie { get; set; }

        [Required(ErrorMessage = "TypeName  is required.")]
        [StringLength(100, ErrorMessage = "TypeName cannot exceed 100 characters.")]
        public string SpecieName { get; set; }

        [Required(ErrorMessage = "TypeName  is required.")]
        [StringLength(100, ErrorMessage = "TypeName cannot exceed 100 characters.")]

        public string SpecieNode { get; set; }
        [Required(ErrorMessage = "Please select a company.")]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public string CompanyName { get; set; }

         public IEnumerable<Company>companies { get; set; }

    }
}
