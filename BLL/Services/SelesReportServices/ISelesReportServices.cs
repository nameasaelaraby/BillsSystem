using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SelesReportServices
{
    public interface ISelesReportServices
    {
        Task Create(SelesReportVM SelesReportVM);
        Task Delete(SelesReportVM SelesReportVM);
        Task Edit(SelesReportVM SelesReportVM);
        Task<List<SelesReportVM>> GetAll();
        Task<SelesReportVM> GetById(int id);
    }
}
