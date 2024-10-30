using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.DataAccess.EFCoreBase.Abstract
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetAllActivePersons();
        Task<Person?> GetActivePersonById(int id);
        Task CreateNewPerson(PersonDTO person);
        Task UpdatePerson(PersonDTO person);
        Task DeletePersonById(int id);
    }
}
