using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_Entities;
using NTier_ECommerce_Entities.Static;
using System.Threading.Tasks;

namespace NTier_ECommerce_UI.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        public async Task<IActionResult> Index() => View(await _actorsService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> AddActor([Bind("NameSurname,ProfileUrl,Biography")] Actors actor) =>
            await ProcessFormSubmissionAsync(actor, () => _actorsService.AddAsync(actor), nameof(Index));

        public async Task<IActionResult> Details(int id) => await GetViewResultForEntityAsync(id);

        public async Task<IActionResult> Edit(int id) => await GetViewResultForEntityAsync(id);

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameSurname,ProfileUrl,Biography")] Actors actor) =>
            await ProcessFormSubmissionAsync(actor, () => _actorsService.UpdateAsync(id, actor), nameof(Index));

        public async Task<IActionResult> Delete(int id) => await GetViewResultForEntityAsync(id);

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) =>
            await ProcessFormSubmissionAsync(null, () => _actorsService.DeleteAsync(id), nameof(Index));

        private async Task<IActionResult> GetViewResultForEntityAsync(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            return actorDetails == null ? View("NotFound") : View(actorDetails);
        }

        private async Task<IActionResult> ProcessFormSubmissionAsync(Actors actor, Func<Task> action, string redirectToAction)
        {
            if (!ModelState.IsValid) return View(actor);

            await action.Invoke();
            return RedirectToAction(redirectToAction);
        }
    }
}
