using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemNode { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
       
        public int CompanyID { get; set; }
        public int SpecieId { get; set; }
       
       

    }
}
