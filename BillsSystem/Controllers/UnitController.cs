using Microsoft.AspNetCore.Mvc;
using DAL.ViewModels;
using BLL.Services.UnitServices;
using System.Threading.Tasks;

namespace BillsSystem.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitServices _unitService; // تعديل هنا، استخدم اسم مختلف

        public UnitController(IUnitServices unitService)
        {
            _unitService = unitService; // استخدام المتغير المعدل هنا
        }

        // GET: Unit
        public async Task<IActionResult> Index()
        {
            var units = await _unitService.GetAll(); // استخدام المتغير المعدل هنا
            return View(units);
        }

        // GET: Unit/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var unit = await _unitService.GetById(id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Unit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitVM unitVM)
        {
            if (ModelState.IsValid)
            {
                await _unitService.Create(unitVM); // استخدام المتغير المعدل هنا
                return RedirectToAction(nameof(Index));
            }
            return View(unitVM);
        }

        // GET: Unit/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var unit = await _unitService.GetById(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: Unit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnitVM unitVM)
        {
            if (id != unitVM.UnitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitService.Edit(unitVM);
                return RedirectToAction(nameof(Index));
            }
            return View(unitVM);
        }

        // GET: Unit/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var unit = await _unitService.GetById(id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Unit/DeleteConfirmed
        [HttpPost]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(UnitVM unitVM)
        {
            if (unitVM == null)
            {
                return NotFound();
            }

            await _unitService.Delete(unitVM);

            TempData["Message"] = "Unit deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
