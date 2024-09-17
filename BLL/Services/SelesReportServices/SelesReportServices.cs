using AutoMapper;
using DAL.Entity;
using DAL.Repo.SelesReportRepo;
using DAL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.SelesReportServices
{
    public class SelesReportServices : ISelesReportServices
    {
        private readonly ISelesReportRepo _selesReportRepo;
        private readonly IMapper _mapper;

        public SelesReportServices(ISelesReportRepo selesReportRepo, IMapper mapper)
        {
            _selesReportRepo = selesReportRepo;
            _mapper = mapper;
        }

        public async Task Create(SelesReportVM selesReportVM)
        {
            var selesReport = _mapper.Map<SelesReport>(selesReportVM);
            await _selesReportRepo.Create(selesReport);
        }

        public async Task Delete(SelesReportVM selesReportVM)
        {
            var selesReport = _mapper.Map<SelesReport>(selesReportVM);
            await _selesReportRepo.Delete(selesReport);
        }

        public async Task Edit(SelesReportVM selesReportVM)
        {
            var selesReport = _mapper.Map<SelesReport>(selesReportVM);
            await _selesReportRepo.Edit(selesReport);
        }

        public async Task<List<SelesReportVM>> GetAll()
        {
            var data = await _selesReportRepo.GetAll();
            return _mapper.Map<List<SelesReportVM>>(data);
        }

        public async Task<SelesReportVM> GetById(int id)
        {
            var selesReport = await _selesReportRepo.GetById(id);
            return _mapper.Map<SelesReportVM>(selesReport);
        }
    }
}
