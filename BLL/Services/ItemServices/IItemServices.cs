using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ItemServices
{
    public interface IItemServices
    {
        Task Create(ItemVM ItemVM);
        Task Delete(ItemVM ItemVM);
        Task Edit(ItemVM ItemVM);
        Task<List<ItemVM>> GetAll();
        Task<ItemVM> GetById(int id);
    }
}
