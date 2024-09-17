using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class SelesReport
    {
        public int SelesReportID { get; set; }

        public string SelesReportName { get; set; }

        
        public int BillNumber { get; set; }

        
        [ForeignKey("BillNumber")]
        public Bill Bill { get; set; }
    }
}
