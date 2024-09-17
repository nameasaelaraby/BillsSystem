using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class BillVM
    {
        [Key]
        public int BillNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BillDate { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int SpecieId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Selling Price must be greater than zero.")]
        public decimal SellingPrice { get; set; }

        
        public decimal TotalValue => SellingPrice * Quantity - ValueDiscount;

        
        [Range(0, 100, ErrorMessage = "Percentage Discount must be between 0 and 100.")]
        public decimal PercentageDiscount { get; set; }

       
        [Range(0, double.MaxValue, ErrorMessage = "Value Discount must be greater than or equal to zero.")]
        public decimal ValueDiscount { get; set; }

       
        public decimal Net => TotalValue - ValueDiscount; 
        public decimal PaidUp { get; set; }

        public decimal Rest => Net - PaidUp;

        
        public void ValidatePaidUp()
        {
            if (PaidUp < 0)
            {
                throw new ArgumentException("Paid Up must be greater than or equal to zero.");
            }
        }
    }
}
