using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_Entities.Static;
using NTier_ECommerce_Entities;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index() => View(await _service.GetAllAsync());

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id) => await GetViewResultForEntityAsync(id);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer) =>
            await ProcessFormSubmissionAsync(producer.Id, async () => await _service.AddAsync(producer), nameof(Index));

        public async Task<IActionResult> Edit(int id) => await GetViewResultForEntityAsync(id);

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer) =>
            await ProcessFormSubmissionAsync(producer.Id, async () => await _service.UpdateAsync(id, producer), nameof(Index));

        public async Task<IActionResult> Delete(int id) => await GetViewResultForEntityAsync(id);

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) =>
            await ProcessFormSubmissionAsync(id, async () => await _service.DeleteAsync(id), nameof(Index));

        private async Task<IActionResult> GetViewResultForEntityAsync(int id)
        {
            var entityDetails = await _service.GetByIdAsync(id);
            return entityDetails == null ? View("NotFound") : View(entityDetails);
        }

        private async Task<IActionResult> ProcessFormSubmissionAsync(int id, Func<Task> action, string redirectToAction)
        {
            if (id <= 0) return View("NotFound");

            await action.Invoke();
            return RedirectToAction(redirectToAction);
        }
    }
}
