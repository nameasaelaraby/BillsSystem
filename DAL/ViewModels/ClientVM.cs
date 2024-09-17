using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ClientVM
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "CLIENT NAME is Required.")]
        [StringLength(100, ErrorMessage = "CLIENT NAME cannot exceed 100 characters.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "PHONE is Required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PHONE must be exactly 11 digits.")]
        public string Phone { get; set; }

        public int Number { get; set; } // This field will be auto-generated and disabled in the view

        [Required(ErrorMessage = "Address is Required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; }
    }

}
