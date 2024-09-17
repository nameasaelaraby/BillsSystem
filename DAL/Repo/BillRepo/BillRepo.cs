using DAL.database;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repo.BillRepo
{
    public class BillRepo : IBillRepo
    {
        private readonly DatabaseDbContext _db;

        public BillRepo(DatabaseDbContext db)
        {
            _db = db;
        }

        public async Task Create(Bill bill)
        {
            _db.Bills.Add(bill);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Bill bill)
        {
            _db.Bills.Update(bill);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Bill>> GetAll()
        {
            return await Get();
        }

        private async Task<List<Bill>> Get()
        {
            var data = await _db.Bills.ToListAsync();
            return data;
        }

        public async Task<Bill> GetById(int id)
        {
            var data = await _db.Bills.Where(x => x.BillNumber == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Delete(Bill bill)
        {
            _db.Bills.Remove(bill);
            await _db.SaveChangesAsync();
        }
    }
}
