using Microsoft.AspNetCore.Mvc;
using ScreenTime.Data.Services;
using ScreenTime.Models;

namespace ScreenTime.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAll();
            return View(allCinemas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetById(id);
            if(details == null) return View("NotFound");
            return View(details);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetById(id);

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.Update(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _service.GetById(id);
            if (cinema == null) return View("NotFound");
            return View(cinema);
        }

        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinema = await _service.GetById(id);
            if (cinema == null) return View("NotFound");
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
