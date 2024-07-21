using Microsoft.AspNetCore.Mvc;
using ScreenTime.Data.Services;
using ScreenTime.Models;

namespace ScreenTime.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails = await _service.GetById(id);

            if (actorDetails == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
