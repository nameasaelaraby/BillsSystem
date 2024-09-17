using AutoMapper;
using DAL.Entity;
using DAL.Repo.CompanyRepo;
using DAL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.CompanyServices
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepo _companyRepo;
        private readonly IMapper _mapper;

        public CompanyServices(ICompanyRepo companyRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        public async Task Create(CompanyVM companyVM)
        {
            var company = _mapper.Map<Company>(companyVM);
            await _companyRepo.Create(company);
        }

        public async Task Delete(CompanyVM companyVM)
        {
            var company = _mapper.Map<Company>(companyVM);
            await _companyRepo.Delete(company);
        }

        public async Task Edit(CompanyVM companyVM)
        {
            var company = _mapper.Map<Company>(companyVM);
            await _companyRepo.Edit(company);
        }

        public async Task<List<CompanyVM>> GetAll()
        {
            var data = await _companyRepo.GetAll();
            return _mapper.Map<List<CompanyVM>>(data);
        }

        public async Task<CompanyVM> GetById(int id)
        {
            var company = await _companyRepo.GetById(id);
            return _mapper.Map<CompanyVM>(company);
        }
    }
}
