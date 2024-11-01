using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Models.DTO;
using PhoneBookUI.ApiServices;
using PhoneBookUI.Models;
using System.Diagnostics;

namespace PhoneBookUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonApiService _service;

        public HomeController(ILogger<HomeController> logger, PersonApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var persons = await _service.GetAllActivePersons();
            return View(persons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> AddPage()
        {
            var categories = await _service.GetCategoriesAsync();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonDTO person)
        {
            if (ModelState.IsValid)
            {
                await _service.AddPersonAsync(person);
                return RedirectToAction("Index");
            }
            var categories = await _service.GetCategoriesAsync();
            ViewBag.Categories = categories;
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePerson(int id)
        {
            _service.DeletePersonAsync(id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
