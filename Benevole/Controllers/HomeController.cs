using Benevole.Models;
using Benevole.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Benevole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class BenevoleController : Controller
    {
        private readonly IBenevoleService _benevoleService;

        public BenevoleController(IBenevoleService benevoleService)
        {
            _benevoleService = benevoleService;
        }

        public async Task<IActionResult> Index()
        {
            var benevoles = await _benevoleService.GetAllAsync();
            return View(benevoles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BenevoleModel benevole)
        {
            if (ModelState.IsValid)
            {
                await _benevoleService.AddAsync(benevole);
                TempData["Success"] = "Benevole ajouter avec succes.";
                return RedirectToAction(nameof(Index));
            }
            return View(benevole);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var benevole = await _benevoleService.GetByIdAsync(id);
            if (benevole == null)
            {
                return NotFound();
            }
            return View(benevole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BenevoleModel benevole)
        {
            if (id != benevole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _benevoleService.UpdateAsync(benevole);
                TempData["Success"] = "Benevole mis a jour avec succes.";
                return RedirectToAction(nameof(Index));
            }
            return View(benevole);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var benevole = await _benevoleService.GetByIdAsync(id);
            if (benevole == null)
            {
                return NotFound();
            }
            return View(benevole);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _benevoleService.DeleteAsync(id);
            TempData["Success"] = "Bénévole supprimé avec succès.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var benevole = await _benevoleService.GetByIdAsync(id);
            if (benevole == null)
            {
                return NotFound();
            }
            return View(benevole);
        }
    }
}
