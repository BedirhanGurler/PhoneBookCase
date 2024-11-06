using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.Business.Abstract
{
    public interface IPersonService
    {
        IQueryable<PersonDTO> GetAllActivePersons();
        IQueryable<PersonDTO> GetAllInactivePersons();
        Task<Person> GetActivePersonById(int id);
        Task CreateNewPerson(PersonDTO person);
        Task UpdatePerson(PersonDTO person);
        Task DeletePersonById(int id);
        Task ActivatePerson(int id);
    }
}
