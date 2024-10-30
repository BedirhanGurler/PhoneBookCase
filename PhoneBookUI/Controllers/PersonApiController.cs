using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Business.Abstract;
using PhoneBookUI.ApiServices;

namespace PhoneBookUI.Controllers
{
    public class PersonApiController : Controller
    {
        private readonly PersonApiService _service;

        public PersonApiController(PersonApiService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()    
        {
            var persons = await _service.GetAllActivePersons();
            return View(persons);
        }
    }
}
