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
    }
}
