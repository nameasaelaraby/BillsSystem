using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.UnitServices
{
    public interface IUnitServices
    {
        Task Create(UnitVM UnitVM);
        Task Delete(UnitVM UnitVM);
        Task Edit(UnitVM UnitVM);
        Task<List<UnitVM>> GetAll();
        Task<UnitVM> GetById(int id);
    }
}
