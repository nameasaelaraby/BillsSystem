using Microsoft.AspNetCore.Mvc;
using DAL.ViewModels;
using BLL.Services.BillServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Repo.ClientRepo;
using DAL.Repo.ItemRepo;
using DAL.Repo.SpecieRepo;

namespace BillsSystem.Controllers
{
    public class BillController : Controller
    {
        private readonly IClientRepo _clientRepo;
        private readonly IItemRepo _itemRepo;
        private readonly ISpecieRepo _specieRepo;
        private readonly IBillServices _billServices;

        public BillController(IClientRepo clientRepo, IItemRepo itemRepo, ISpecieRepo specieRepo, IBillServices billServices)
        {
            _clientRepo = clientRepo;
            _itemRepo = itemRepo;
            _specieRepo = specieRepo;
            _billServices = billServices;
        }

        public async Task<IActionResult> Index()
        {
            var bills = await _billServices.GetAll();
            return View(bills);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bill = await _billServices.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clients = await _clientRepo.GetAll();
            var items = await _itemRepo.GetAll();
            var species = await _specieRepo.GetAll();

            ViewBag.Clients = clients.Select(c => new SelectListItem
            {
                Value = c.ClientId.ToString(),
                Text = c.ClientName
            }).ToList();

            ViewBag.Items = items.Select(i => new SelectListItem
            {
                Value = i.ItemId.ToString(),
                Text = i.ItemName
            }).ToList();

            ViewBag.Species = species.Select(s => new SelectListItem
            {
                Value = s.SpecieId.ToString(),
                Text = s.SpecieName
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillVM billVM)
        {
            if (!ModelState.IsValid)
            {
                var clients = await _clientRepo.GetAll();
                var items = await _itemRepo.GetAll();
                var species = await _specieRepo.GetAll();

                ViewBag.Clients = clients.Select(c => new SelectListItem
                {
                    Value = c.ClientId.ToString(),
                    Text = c.ClientName
                }).ToList();

                ViewBag.Items = items.Select(i => new SelectListItem
                {
                    Value = i.ItemId.ToString(),
                    Text = i.ItemName
                }).ToList();

                ViewBag.Species = species.Select(s => new SelectListItem
                {
                    Value = s.SpecieId.ToString(),
                    Text = s.SpecieName
                }).ToList();

                return View(billVM);
            }

            await _billServices.Create(billVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var bill = await _billServices.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }

            ViewBag.Clients = (await _clientRepo.GetAll()).Select(c => new SelectListItem
            {
                Value = c.ClientId.ToString(),
                Text = c.ClientName
            }).ToList();

            ViewBag.Items = (await _itemRepo.GetAll()).Select(i => new SelectListItem
            {
                Value = i.ItemId.ToString(),
                Text = i.ItemName
            }).ToList();

            ViewBag.Species = (await _specieRepo.GetAll()).Select(s => new SelectListItem
            {
                Value = s.SpecieId.ToString(),
                Text = s.SpecieName
            }).ToList();

            return View(bill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BillVM billVM)
        {
            if (id != billVM.BillNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _billServices.Edit(billVM);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clients = (await _clientRepo.GetAll()).Select(c => new SelectListItem
            {
                Value = c.ClientId.ToString(),
                Text = c.ClientName
            }).ToList();

            ViewBag.Items = (await _itemRepo.GetAll()).Select(i => new SelectListItem
            {
                Value = i.ItemId.ToString(),
                Text = i.ItemName
            }).ToList();

            ViewBag.Species = (await _specieRepo.GetAll()).Select(s => new SelectListItem
            {
                Value = s.SpecieId.ToString(),
                Text = s.SpecieName
            }).ToList();

            return View(billVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var bill = await _billServices.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        [HttpPost]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _billServices.GetById(id);
            if (bill == null)
            {
                return NotFound();
            }

            await _billServices.Delete(bill);
            TempData["Message"] = "Bill deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
