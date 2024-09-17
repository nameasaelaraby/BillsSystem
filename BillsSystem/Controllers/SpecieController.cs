using BLL.Services.SpecieServices;
using DAL.Repo.CompanyRepo;
using DAL.ViewModels;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace BillsSystem.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ISpecieServices _specieServices;
        private readonly ICompanyRepo _companyRepo;

        public SpecieController(ISpecieServices specieServices, ICompanyRepo companyRepo)
        {
            _specieServices = specieServices;
            _companyRepo = companyRepo;
        }

        // Index - List all species
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allData = await _specieServices.GetAll();
            var allComp =  await _companyRepo.GetAll();

            var AllDataVM = allData.Select(x => new SpecieVM
            {
                SpecieId=x.SpecieId,
                SpecieName=x.SpecieName,
                SpecieNode=x.SpecieNode,
                CompanyID=x.CompanyID,
                CompanyName=allComp.FirstOrDefault(c=>c.CompanyID == x.CompanyID)?.CompanyName

            }).ToList();
       
            return View(AllDataVM);
        }

        // Create - GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companies = await _companyRepo.GetAll();

            ViewBag.Companies = companies.Select(c => new SelectListItem
            {
                Value = c.CompanyID.ToString(),
                Text = c.CompanyName
            }).ToList();

            return View();
        }

        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecieVM specieVM)
        {
            if (ModelState.IsValid)
            {
                var companies = await _companyRepo.GetAll();

                ViewBag.Companies = companies.Select(c => new SelectListItem
                {
                    Value = c.CompanyID.ToString(),
                    Text = c.CompanyName
                }).ToList();

                return View(specieVM);
            }

            await _specieServices.Create(specieVM);
            return RedirectToAction("Index");
        }

        // Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var specie = await _specieServices.GetById(id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // Edit - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var specie = await _specieServices.GetById(id);
            if (specie == null)
            {
                return NotFound();
            }

            var companies = await _companyRepo.GetAll();

            ViewBag.Companies = companies.Select(c => new SelectListItem
            {
                Value = c.CompanyID.ToString(),
                Text = c.CompanyName
            }).ToList();

            return View(specie);
        }

        // Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecieVM specieVM)
        {
            if (ModelState.IsValid)
            {
                var companies = await _companyRepo.GetAll();

               



                ViewBag.Companies = companies.Select(c => new SelectListItem
                {
                    Value = c.CompanyID.ToString(),
                    Text = c.CompanyName
                }).ToList();

                return View(specieVM);
            }

            await _specieServices.Edit(specieVM);
            return RedirectToAction("Index");
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var specie = await _specieServices.GetById(id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // POST: Company/DeleteConfirmed
        [HttpPost]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(SpecieVM specieVM)
        {
            if (specieVM == null)
            {
                return NotFound();
            }

            await _specieServices.Delete(specieVM);

            TempData["Message"] = "Company deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
       
        }
    }

