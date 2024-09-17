using BLL.Services.ItemServices;
using BLL.Services.SpecieServices;
using DAL.Repo.CompanyRepo;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace BillsSystem.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemServices _itemServices;
        private readonly ICompanyRepo _companyRepo;
        private readonly ISpecieServices _specieServices;

        public ItemController(IItemServices itemServices, ICompanyRepo companyRepo, ISpecieServices specieServices)
        {
            _itemServices = itemServices;
            _companyRepo = companyRepo;
            _specieServices = specieServices;
        }

        // Index - List all items
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var itemList = await _itemServices.GetAll();
            return View(itemList);
        }

        // Create - GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companies = await _companyRepo.GetAll();
            var species = await _specieServices.GetAll();

            ViewBag.Companies = companies.Select(c => new SelectListItem
            {
                Value = c.CompanyID.ToString(),
                Text = c.CompanyName
            }).ToList();

            ViewBag.Species = species.Select(s => new SelectListItem
            {
                Value = s.SpecieId.ToString(),
                Text = s.SpecieName
            }).ToList();

            return View();
        }

        // Create - POST
        [HttpPost]
        public async Task<IActionResult> Create(ItemVM itemVM)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _companyRepo.GetAll();
                var species = await _specieServices.GetAll();

                ViewBag.Companies = companies.Select(c => new SelectListItem
                {
                    Value = c.CompanyID.ToString(),
                    Text = c.CompanyName
                }).ToList();

                ViewBag.Species = species.Select(s => new SelectListItem
                {
                    Value = s.SpecieId.ToString(),
                    Text = s.SpecieName
                }).ToList();

                return View(itemVM);
            }

            await _itemServices.Create(itemVM);
            return RedirectToAction("Index");
        }

        // Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _itemServices.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // Edit - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _itemServices.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            var companies = await _companyRepo.GetAll();
            var species = await _specieServices.GetAll();

            ViewBag.Companies = companies.Select(c => new SelectListItem
            {
                Value = c.CompanyID.ToString(),
                Text = c.CompanyName
            }).ToList();

            ViewBag.Species = species.Select(s => new SelectListItem
            {
                Value = s.SpecieId.ToString(),
                Text = s.SpecieName
            }).ToList();

            return View(item);
        }

        // Edit - POST
        [HttpPost]
        public async Task<IActionResult> Edit(ItemVM itemVM)
        {
            if (!ModelState.IsValid)
            {
                var companies = await _companyRepo.GetAll();
                var species = await _specieServices.GetAll();

                ViewBag.Companies = companies.Select(c => new SelectListItem
                {
                    Value = c.CompanyID.ToString(),
                    Text = c.CompanyName
                }).ToList();

                ViewBag.Species = species.Select(s => new SelectListItem
                {
                    Value = s.SpecieId.ToString(),
                    Text = s.SpecieName
                }).ToList();

                return View(itemVM);
            }

            await _itemServices.Edit(itemVM);
            return RedirectToAction("Index");
        }



        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemServices.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Company/DeleteConfirmed
        [HttpPost]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ItemVM itemVM)
        {
            if (itemVM == null)
            {
                return NotFound();
            }

            await _itemServices.Delete(itemVM);

            TempData["Message"] = "item deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }


}
