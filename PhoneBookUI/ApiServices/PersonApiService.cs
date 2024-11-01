using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookUI.ApiServices
{
    public class PersonApiService
    {
        private readonly HttpClient _httpClient;

        public PersonApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PersonDTO>> GetAllActivePersons()
        {
            var response = await _httpClient.GetAsync("api/Persons/get-active-persons");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<PersonDTO>>();
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/Categories/categories");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Category>>();
            }
            return new List<Category>();
        }

        public async Task AddPersonAsync(PersonDTO person)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Persons/add-new-person", person);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePersonAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Persons/delete-person/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
