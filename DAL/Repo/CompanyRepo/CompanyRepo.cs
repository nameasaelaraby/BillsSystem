using DAL.database;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repo.CompanyRepo
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly DatabaseDbContext _db;

        public CompanyRepo(DatabaseDbContext db)
        {
            _db = db;
        }

        public async Task Create(Company company)
        {
            _db.Companys.Add(company);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Company company)
        {
            _db.Companys.Update(company);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAll()
        {
            return await Get();
        }

        private async Task<List<Company>> Get()
        {
            var data = await _db.Companys.ToListAsync();
            return data;
        }

        public async Task<Company> GetById(int id)
        {
            var data = await _db.Companys.Where(x => x.CompanyID == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task Delete(Company company)
        {
            _db.Companys.Remove(company);
            await _db.SaveChangesAsync();
        }
    }
}
