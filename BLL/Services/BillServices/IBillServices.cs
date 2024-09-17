using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.BillServices
{
    public interface IBillServices
    {
        Task Create(BillVM BillVM);
        Task Delete(BillVM BillVM);
        Task Edit(BillVM BillVM);
        Task<List<BillVM>> GetAll();
        Task<BillVM> GetById(int id);
    }
}
