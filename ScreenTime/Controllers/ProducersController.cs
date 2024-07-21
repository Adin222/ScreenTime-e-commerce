using Microsoft.AspNetCore.Mvc;
using ScreenTime.Data.Services;
using ScreenTime.Models;

namespace ScreenTime.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAll();
            return View(allProducers);
        }
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.Add(producer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _service.GetById(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if(id == producer.Id)
            {
               await _service.Update(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _service.GetById(id);
            if (producer == null) return View("NotFound");
            return View(producer);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producer = await _service.GetById(id);
            if (producer == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
