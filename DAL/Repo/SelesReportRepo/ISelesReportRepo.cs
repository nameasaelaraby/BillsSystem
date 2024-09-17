using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.SelesReportRepo
{
    public interface ISelesReportRepo
    {
        Task Create(SelesReport SelesReport);
        Task Delete(SelesReport SelesReport);
        Task Edit(SelesReport SelesReport);
        Task<List<SelesReport>> GetAll();
        Task<SelesReport> GetById(int id);

    }
}
