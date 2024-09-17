using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ClientServices
{
    public interface IClientServices
    {
        Task Create(ClientVM ClientVM);
        Task Delete(ClientVM ClientVM);
        Task Edit(ClientVM ClientVM);
        Task<List<ClientVM>> GetAll();
        Task<ClientVM> GetById(int id);
    }
}
