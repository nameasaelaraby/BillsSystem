using BLL.Services.SelesReportServices;
using DAL.Repo.BillRepo;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace BillsSystem.Controllers
{
    public class SelesReportController : Controller
    {
        private readonly ISelesReportServices _selesReportServices;
        private readonly IBillRepo _billRepo;

        public SelesReportController(ISelesReportServices selesReportServices, IBillRepo billRepo)
        {
            _selesReportServices = selesReportServices;
            _billRepo = billRepo;
        }

        // Index - List all sales reports
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var selesReportList = await _selesReportServices.GetAll();
            return View(selesReportList);
        }

        // Create - GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var bills = await _billRepo.GetAll();
            ViewBag.Bills = bills.Select(b => new SelectListItem
            {
                Value = b.BillNumber.ToString(),
                Text = b.BillDate.ToShortDateString()
            }).ToList();

            return View();
        }

        // Create - POST
        [HttpPost]
        public async Task<IActionResult> Create(SelesReportVM selesReportVM)
        {
            if (ModelState.IsValid)
            {
                var bills = await _billRepo.GetAll();
                ViewBag.Bills = bills.Select(b => new SelectListItem
                {
                    Value = b.BillNumber.ToString(),
                    Text = b.BillDate.ToShortDateString()
                }).ToList();

                return View(selesReportVM);
            }

            await _selesReportServices.Create(selesReportVM);
            return RedirectToAction("Index");
        }

        // Details - GET
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var selesReport = await _selesReportServices.GetById(id);
            if (selesReport == null)
            {
                return NotFound();
            }

            return View(selesReport);
        }

        // Edit - GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var selesReport = await _selesReportServices.GetById(id);
            if (selesReport == null)
            {
                return NotFound();
            }

            var bills = await _billRepo.GetAll();
            ViewBag.Bills = bills.Select(b => new SelectListItem
            {
                Value = b.BillNumber.ToString(),
                Text = b.BillDate.ToShortDateString()
            }).ToList();

            return View(selesReport);
        }

        // Edit - POST
        [HttpPost]
        public async Task<IActionResult> Edit(SelesReportVM selesReportVM)
        {
            if (ModelState.IsValid)
            {
                var bills = await _billRepo.GetAll();
                ViewBag.Bills = bills.Select(b => new SelectListItem
                {
                    Value = b.BillNumber.ToString(),
                    Text = b.BillDate.ToShortDateString()
                }).ToList();

                return View(selesReportVM);
            }

            await _selesReportServices.Edit(selesReportVM);
            return RedirectToAction("Index");
        }

        // Delete - GET
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var selesReport = await _selesReportServices.GetById(id);
            if (selesReport == null)
            {
                return NotFound();
            }

            return View(selesReport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(SelesReportVM selesReportVM)
        {
            if (selesReportVM == null || selesReportVM.SelesReportID <= 0)
            {
                return NotFound();
            }

            // الحصول على الكائن من قاعدة البيانات باستخدام المفتاح الأساسي
            var selesReport = await _selesReportServices.GetById(selesReportVM.SelesReportID);
            if (selesReport == null)
            {
                return NotFound();
            }

            await _selesReportServices.Delete(selesReport);
            return RedirectToAction("Index");
        }

    }
}
