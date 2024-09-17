using AutoMapper;
using DAL.Entity;
using DAL.Repo.ItemRepo;
using DAL.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.ItemServices
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepo _itemRepo;
        private readonly IMapper _mapper;

        public ItemServices(IItemRepo itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }

        public async Task Create(ItemVM itemVM)
        {
            var item = _mapper.Map<Item>(itemVM);
            await _itemRepo.Create(item);
        }

        public async Task Delete(ItemVM itemVM)
        {
            var item = _mapper.Map<Item>(itemVM);
            await _itemRepo.Delete(item);
        }

        public async Task Edit(ItemVM itemVM)
        {
            var item = _mapper.Map<Item>(itemVM);
            await _itemRepo.Edit(item);
        }

        public async Task<List<ItemVM>> GetAll()
        {
            var data = await _itemRepo.GetAll();
            return _mapper.Map<List<ItemVM>>(data);
        }

        public async Task<ItemVM> GetById(int id)
        {
            var item = await _itemRepo.GetById(id);
            return _mapper.Map<ItemVM>(item);
        }
    }
}
