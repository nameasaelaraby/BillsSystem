using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class CompanyVM
    {

        public int CompanyID { get; set; }
        [Required(ErrorMessage = "COMPANY NAME is Required")]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "COMPANY Note is Required")]
        
        public string CompanyNote { get; set; }

    }
}
