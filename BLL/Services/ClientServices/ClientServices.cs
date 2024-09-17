using AutoMapper;
using DAL.Entity;
using DAL.Repo.ClientRepo;
using DAL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.ClientServices
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepo _clientRepo;
        private readonly IMapper _mapper;

        public ClientServices(IClientRepo clientRepo, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        public async Task Create(ClientVM clientVM)
        {
            var client = _mapper.Map<Client>(clientVM);
            await _clientRepo.Create(client);
        }

        public async Task Delete(ClientVM clientVM)
        {
            var client = _mapper.Map<Client>(clientVM);
            await _clientRepo.Delete(client);
        }

        public async Task Edit(ClientVM clientVM)
        {
            var client = _mapper.Map<Client>(clientVM);
            await _clientRepo.Edit(client);
        }

        public async Task<List<ClientVM>> GetAll()
        {
            var data = await _clientRepo.GetAll();
            return _mapper.Map<List<ClientVM>>(data);
        }

        public async Task<ClientVM> GetById(int id)
        {
            var client = await _clientRepo.GetById(id);
            return _mapper.Map<ClientVM>(client);
        }
    }
}
