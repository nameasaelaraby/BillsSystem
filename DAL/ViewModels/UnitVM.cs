using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class UnitVM
    {

        public int UnitID { get; set; }
        [Required(ErrorMessage = "COMPANY NAME is Required")]
        [StringLength(100)]
        public string UnitName { get; set; }
        [Required(ErrorMessage = "COMPANY Note is Required")]

        public string UnitNote { get; set; }
    }
}
