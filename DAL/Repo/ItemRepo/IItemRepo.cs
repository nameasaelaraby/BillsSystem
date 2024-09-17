using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.ItemRepo
{
    public interface IItemRepo
    {
        Task Create(Item Item);
        Task Delete(Item Item);
        Task Edit(Item Item);
        Task<List<Item>> GetAll();
        Task<Item> GetById(int id);
    }
}
