using AutoMapper;
using DAL.Entity;
using DAL.Repo.BillRepo;
using DAL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.BillServices
{
    public class BillServices : IBillServices
    {
        private readonly IBillRepo _billRepo;
        private readonly IMapper _mapper;

        public BillServices(IBillRepo billRepo, IMapper mapper)
        {
            _billRepo = billRepo;
            _mapper = mapper;
        }

        public async Task Create(BillVM billVM)
        {
            var bill = _mapper.Map<Bill>(billVM);
            await _billRepo.Create(bill);
        }

        public async Task Delete(BillVM billVM)
        {
            var bill = _mapper.Map<Bill>(billVM);
            await _billRepo.Delete(bill);
        }

        public async Task Edit(BillVM billVM)
        {
            var bill = _mapper.Map<Bill>(billVM);
            await _billRepo.Edit(bill);
        }

        public async Task<List<BillVM>> GetAll()
        {
            var data = await _billRepo.GetAll();
            return _mapper.Map<List<BillVM>>(data);
        }

        public async Task<BillVM> GetById(int id)
        {
            var bill = await _billRepo.GetById(id);
            return _mapper.Map<BillVM>(bill);
        }
    }
}
