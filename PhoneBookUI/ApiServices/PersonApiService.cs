using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;
using System.Text;
using System.Text.Json;

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

        public async Task<PersonDTO> GetPersonByID(int id)
        {
            var response = await _httpClient.GetAsync($"api/Persons/get-by-id/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PersonDTO>();
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


        public async Task AddCategoryAsync(CategoryDTO category)
        {
            
            var response = await _httpClient.PostAsJsonAsync("api/Categories/add-category", category);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdatePersonAsync(PersonDTO person)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Persons/update-person/{person.PersonID}", person);
            response.EnsureSuccessStatusCode();
        }
    }
}
