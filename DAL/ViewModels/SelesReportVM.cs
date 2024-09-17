using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class SelesReportVM
    {
        
            public int SelesReportID { get; set; }

            [Required(ErrorMessage = "Sales Report Name is required.")]
            [StringLength(100, ErrorMessage = "Sales Report Name can't be longer than 100 characters.")]
            public string SelesReportName { get; set; }

            [Required(ErrorMessage = "Bill Number is required.")]
            public int BillNumber { get; set; }

            
            public BillVM Bill { get; set; }
        }
    }

