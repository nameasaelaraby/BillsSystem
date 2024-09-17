using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.CompanyServices
{
    public interface ICompanyServices
    {
        Task Create(CompanyVM CompanyVM);
        Task Delete(CompanyVM CompanyVM);
        Task Edit(CompanyVM CompanyVM);
        Task<List<CompanyVM>> GetAll();
        Task<CompanyVM> GetById(int id);
    }
}
