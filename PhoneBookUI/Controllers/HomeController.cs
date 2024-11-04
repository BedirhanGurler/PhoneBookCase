using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Models.Concrete;
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
            await _service.DeletePersonAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePersonPage(int id)
        {
            var person = await _service.GetPersonByID(id);
            if (person == null)
            {
                return NotFound();
            }
            var categories = await _service.GetCategoriesAsync();
            ViewBag.Categories = categories;
            return View(person);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePerson(PersonDTO person)
        {
            await _service.UpdatePersonAsync(person);
            var categories = await _service.GetCategoriesAsync();
            ViewBag.Categories = categories;
            return RedirectToAction("Index");   


        }

        public async Task<IActionResult> AddCategoryPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCategoryAsync(category);
                return RedirectToAction("Index");
            }
            return View("AddCategoryPage");
        }

        public async Task<IActionResult> Categories()
        {
            var categories = await _service.GetCategoriesAsync();
            return View(categories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
