using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ItemVM
    {


        public int ItemId { get; set; }

        [Required(ErrorMessage = "ITEM NAME is Required.")]
        [StringLength(100, ErrorMessage = "ITEM NAME cannot exceed 100 characters.")]
        public string ItemName { get; set; }

        public string ItemNode { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "SELLING PRICE Must be Greater than or equal Zero.")]
        public decimal SellingPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "BUYING PRICE Must be Greater than or equal Zero.")]
        public decimal BuyingPrice { get; set; }
        public int Quantity { get; set; }

        [Required(ErrorMessage = "COMPANY NAME is Required.")]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "TYPE NAME is Required.")]
        public int SpecieId { get; set; }

        public decimal Discount { get; set; }
        public decimal TotalValue => SellingPrice * Quantity - Discount;
    }

    }

