using DAL.database;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repo.ClientRepo
{
    public class ClientRepo : IClientRepo
    {
        private readonly DatabaseDbContext _db;

        public ClientRepo(DatabaseDbContext db)
        {
            _db = db;
        }

        public async Task Create(Client client)
        {
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Client client)
        {
            _db.Clients.Update(client);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAll()
        {
            return await Get();
        }

        private async Task<List<Client>> Get()
        {
            var data = await _db.Clients.ToListAsync();
            return data;
        }

        public async Task<Client> GetById(int id)
        {
            var data = await _db.Clients.Where(x => x.ClientId == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Delete(Client client)
        {
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
        }
    }
}
