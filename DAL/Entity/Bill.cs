using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Entity
{
    public class Bill
    {
        [Key]
        public int BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public int ClientId { get; set; }
        public int SpecieId { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public int SellingPrice { get; set; }
        public decimal TotalValue => SellingPrice * Quantity - valueDiscount;
        public decimal percentageDiscount {  get; set; }
        public decimal valueDiscount {  get; set; }
        public decimal net;
        public decimal paidUp {  get; set; }
        public decimal rest;

    }
}
