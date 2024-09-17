using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SpecieServices
{
    public interface ISpecieServices
    {
        Task Create(SpecieVM SpecieVm);
        Task Delete(SpecieVM SpecieVm);
        Task Edit(SpecieVM SpecieVm);
        Task<List<SpecieVM>> GetAll();
        Task<SpecieVM> GetById(int id);

       
    }
}
