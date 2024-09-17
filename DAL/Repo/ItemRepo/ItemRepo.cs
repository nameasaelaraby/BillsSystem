using DAL.database;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repo.ItemRepo
{
    public class ItemRepo : IItemRepo
    {
        private readonly DatabaseDbContext _db;

        public ItemRepo(DatabaseDbContext db)
        {
            _db = db;
        }

        public async Task Create(Item item)
        {
            _db.Items.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Item item)
        {
            _db.Items.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAll()
        {
            return await Get();
        }

        private async Task<List<Item>> Get()
        {
            var data = await _db.Items.ToListAsync();
            return data;
        }

        public async Task<Item> GetById(int id)
        {
            var data = await _db.Items.Where(x => x.ItemId == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Delete(Item item)
        {
            _db.Items.Remove(item);
            await _db.SaveChangesAsync();
        }
    }
}
