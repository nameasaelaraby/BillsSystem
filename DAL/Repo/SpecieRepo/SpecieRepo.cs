using DAL.database;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repo.SpecieRepo
{
    public class SpecieRepo : ISpecieRepo
    {
        private readonly DatabaseDbContext _db;

        public SpecieRepo(DatabaseDbContext db)
        {
            _db = db;
        }

        public async Task Create(Specie specie)
        {
            _db.Species.Add(specie);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Specie specie)
        {
            _db.Species.Update(specie);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Specie>> GetAll()
        {
            return await Get();
        }

        private async Task<List<Specie>> Get()
        {
            var data = await _db.Species.ToListAsync();
            return data;
        }

        public async Task<Specie> GetById(int id)
        {
            var data = await _db.Species.Where(x => x.SpecieId == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Delete(Specie specie)
        {
            _db.Species.Remove(specie);
            await _db.SaveChangesAsync();
        }
    }
}
