using Microsoft.AspNetCore.Mvc;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_Entities;

namespace NTier_ECommerce_UI.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;
        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetAllActorsAsync();
            return View(data);
        }

        // Get : Actors/AddActor
        [HttpPost]
        public async Task<IActionResult> AddActor([Bind("NameSurname,ProfileUrl,Biography")] Actors actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsService.AddActorAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        // Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorsService.GetActorByIdAsync(id);

            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);
        }

        //Get : Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorsService.GetActorByIdAsync(id);

            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameSurname,ProfileUrl,Biography")] Actors actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsService.UpdateActorAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get : Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorsService.GetActorByIdAsync(id);

            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _actorsService.GetActorByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _actorsService.RemoveActorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
 