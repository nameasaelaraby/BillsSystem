using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.UnitRepo
{
    public interface IUnitRepo
    {
        Task Create(Unit Unit);
        Task Delete(Unit Unit);
        Task Edit(Unit Unit);
        Task<List<Unit>> GetAll();
        Task<Unit> GetById(int id);
    }
}
