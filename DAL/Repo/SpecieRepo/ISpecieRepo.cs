using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.SpecieRepo
{
    public interface ISpecieRepo
    {
        Task Create(Specie Specie);
        Task Delete(Specie Specie);
        Task Edit(Specie Specie);
        Task<List<Specie>> GetAll();
        Task<Specie> GetById(int id);
    }
}
