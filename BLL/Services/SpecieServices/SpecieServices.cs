using AutoMapper;
using DAL.Entity;
using DAL.Repo.SpecieRepo;
using DAL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.SpecieServices
{
    public class SpecieServices : ISpecieServices
    {
        private readonly ISpecieRepo _specieRepo;
        private readonly IMapper _mapper;

        public SpecieServices(ISpecieRepo specieRepo, IMapper mapper)
        {
            _specieRepo = specieRepo;
            _mapper = mapper;
        }

        public async Task Create(SpecieVM specieVm)
        {
            var specie = _mapper.Map<Specie>(specieVm);
            await _specieRepo.Create(specie);
        }

        public async Task Delete(SpecieVM specieVm)
        {
            var specie = _mapper.Map<Specie>(specieVm);
            await _specieRepo.Delete(specie);
        }

        public async Task Edit(SpecieVM specieVm)
        {
            var specie = _mapper.Map<Specie>(specieVm);
            await _specieRepo.Edit(specie);
        }

        public async Task<List<SpecieVM>> GetAll()
        {
            var data = await _specieRepo.GetAll();
            return _mapper.Map<List<SpecieVM>>(data);
        }








        public async Task<SpecieVM> GetById(int id)
        {
            var specie = await _specieRepo.GetById(id);
            return _mapper.Map<SpecieVM>(specie);
        }
    }
}
