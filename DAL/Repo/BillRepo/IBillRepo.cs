using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.BillRepo
{
    public interface IBillRepo
    {
        Task Create(Bill Bill);
        Task Delete(Bill Bill);
        Task Edit(Bill Bill);
        Task<List<Bill>> GetAll();
        Task<Bill> GetById(int id);
    }
}
