using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_Entities;
using NTier_ECommerce_Entities.Static;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index() => View(await _cinemaService.GetAllAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema) =>
            await ProcessFormSubmissionAsync(cinema, () => _cinemaService.AddAsync(cinema), nameof(Index));

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id) => await GetViewResultForEntityAsync(id);

        public async Task<IActionResult> Edit(int id) => await GetViewResultForEntityAsync(id);

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema) =>
            await ProcessFormSubmissionAsync(cinema, () => _cinemaService.UpdateAsync(id, cinema), nameof(Index));

        public async Task<IActionResult> Delete(int id) => await GetViewResultForEntityAsync(id);

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id) =>
            await ProcessFormSubmissionAsync(null, () => _cinemaService.DeleteAsync(id), nameof(Index));

        private async Task<IActionResult> GetViewResultForEntityAsync(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            return cinemaDetails == null ? View("NotFound") : View(cinemaDetails);
        }

        private async Task<IActionResult> ProcessFormSubmissionAsync(Cinema cinema, Func<Task> action, string redirectToAction)
        {
            if (IsModelStateValid(cinema)) return View(cinema);

            await action.Invoke();
            return RedirectToAction(redirectToAction);
        }

        private bool IsModelStateValid(Cinema cinema) => ModelState.IsValid;
    }
}

/*  EXPLANATION 
 */
