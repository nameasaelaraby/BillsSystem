using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.ClientRepo
{
    public interface IClientRepo
    {
        Task Create(Client Client);
        Task Delete(Client Client);
        Task Edit(Client Client);
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);

    }
}
