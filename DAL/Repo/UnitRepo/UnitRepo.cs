using DAL.database;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repo.UnitRepo
{
    public class UnitRepo : IUnitRepo
    {
        private readonly DatabaseDbContext _db;

        public UnitRepo(DatabaseDbContext db)
        {
            _db = db;
        }

        public async Task Create(Unit unit)
        {
            _db.Units.Add(unit);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Unit unit)
        {
            _db.Units.Update(unit);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Unit>> GetAll()
        {
            return await Get();
        }

        private async Task<List<Unit>> Get()
        {
            var data = await _db.Units.ToListAsync();
            return data;
        }

        public async Task<Unit> GetById(int id)
        {
            var data = await _db.Units.Where(x => x.UnitID == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Delete(Unit unit)
        {
            _db.Units.Remove(unit);
            await _db.SaveChangesAsync();
        }
    }
}
