using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Specie
    {
        public int SpecieId { get; set; }
        public string SpecieName { get; set; }
        public string SpecieNode { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
