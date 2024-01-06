using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_Entities;
using NTier_ECommerce_Entities.Static;

namespace NTier_ECommerce_UI.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _cinemaService;
        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            return View(cinemas);
        }

        // Get : Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _cinemaService.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Get: Cinemas/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _cinemaService.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
