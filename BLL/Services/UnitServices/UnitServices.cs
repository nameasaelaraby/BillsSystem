using AutoMapper;
using DAL.Entity;
using DAL.Repo.UnitRepo;
using DAL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.UnitServices
{
    public class UnitServices : IUnitServices
    {
        private readonly IUnitRepo _unitRepo;
        private readonly IMapper _mapper;

        public UnitServices(IUnitRepo unitRepo, IMapper mapper)
        {
            _unitRepo = unitRepo;
            _mapper = mapper;
        }

        public async Task Create(UnitVM unitVM)
        {
            var unit = _mapper.Map<Unit>(unitVM);
            await _unitRepo.Create(unit);
        }

        public async Task Delete(UnitVM unitVM)
        {
            var unit = _mapper.Map<Unit>(unitVM);
            await _unitRepo.Delete(unit);
        }

        public async Task Edit(UnitVM unitVM)
        {
            var unit = _mapper.Map<Unit>(unitVM);
            await _unitRepo.Edit(unit);
        }

        public async Task<List<UnitVM>> GetAll()
        {
            var data = await _unitRepo.GetAll();
            return _mapper.Map<List<UnitVM>>(data);
        }

        public async Task<UnitVM> GetById(int id)
        {
            var unit = await _unitRepo.GetById(id);
            return _mapper.Map<UnitVM>(unit);
        }
    }
}
