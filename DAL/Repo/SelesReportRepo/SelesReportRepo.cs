using DAL.Entity;
using DAL.database; // Adjust this namespace if your DbContext is located elsewhere
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repo.SelesReportRepo
{
    public class SelesReportRepo : ISelesReportRepo
    {
        private readonly DatabaseDbContext _db;

        public SelesReportRepo(DatabaseDbContext db)
        {
            _db = db;
        }

        public async Task Create(SelesReport selesReport)
        {
            _db.SelesReports.Add(selesReport);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(SelesReport selesReport)
        {
            _db.SelesReports.Update(selesReport);
            await _db.SaveChangesAsync();
        }

        public async Task<List<SelesReport>> GetAll()
        {
            return await Get();
        }

        private async Task<List<SelesReport>> Get()
        {
            return await _db.SelesReports.ToListAsync();
        }

        public async Task<SelesReport> GetById(int id)
        {
            return await _db.SelesReports
                .Include(sr => sr.Bill) // Optionally include related entities if needed
                .FirstOrDefaultAsync(sr => sr.SelesReportID == id);
        }

        public async Task Delete(SelesReport selesReport)
        {
            _db.SelesReports.Remove(selesReport);
            await _db.SaveChangesAsync();
        }
    }
}
