using Microsoft.AspNetCore.Mvc;
using DAL.ViewModels;
using BLL.Services.ClientServices;
using System.Threading.Tasks;

namespace BillsSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientServices _clientServices;

        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var clients = await _clientServices.GetAll();
            return View(clients);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = await _clientServices.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientVM clientVM)
        {
            if (ModelState.IsValid)
            {
                await _clientServices.Create(clientVM);
                return RedirectToAction(nameof(Index));
            }
            return View(clientVM);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientServices.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientVM clientVM)
        {
            if (id != clientVM.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _clientServices.Edit(clientVM);
                return RedirectToAction(nameof(Index));
            }
            return View(clientVM);
        }


        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientServices.GetById(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/DeleteConfirmed
        [HttpPost]
        [ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ClientVM clientVM)
        {
            if (clientVM == null)
            {
                return NotFound();
            }

            await _clientServices.Delete(clientVM);

            TempData["Message"] = "Client deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
