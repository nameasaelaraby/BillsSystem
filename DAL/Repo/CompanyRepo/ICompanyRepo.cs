using DAL.Entity;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.CompanyRepo
{
    public interface ICompanyRepo
    {

        Task Create(Company Company);
        Task Delete(Company Company);
        Task Edit(Company Company);
        Task<List<Company>> GetAll();
        Task<Company> GetById(int id);
    }
}
