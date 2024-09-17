using Microsoft.AspNetCore.Mvc;
using DAL.ViewModels;
using BLL.Services.CompanyServices; // Assuming you have a CompanyServices interface in BLL
using System.Threading.Tasks;

namespace BillsSystem.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
            var companies = await _companyServices.GetAll();
            return View(companies);
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var company = await _companyServices.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyVM companyVM)
        {
            if (ModelState.IsValid)
            {
                await _companyServices.Create(companyVM);
                return RedirectToAction(nameof(Index));
            }
            return View(companyVM);
        }

        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyServices.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyVM companyVM)
        {
            if (id != companyVM.CompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _companyServices.Edit(companyVM);
                return RedirectToAction(nameof(Index));
            }
            return View(companyVM);
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _companyServices.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Company/DeleteConfirmed
        [HttpPost]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(CompanyVM companyVM)
        {
            if (companyVM == null)
            {
                return NotFound();
            }

            await _companyServices.Delete(companyVM);

            TempData["Message"] = "Company deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
