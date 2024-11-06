using PhoneBookApi.Business.Abstract;
using PhoneBookApi.DataAccess.EFCoreBase.Abstract;
using PhoneBookApi.DataAccess.EFCoreBase.Concrete;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        public PersonManager(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public async Task ActivatePerson(int id)
        {
            await _personRepo.ActivatePerson(id);
        }

        public async Task CreateNewPerson(PersonDTO person)
        {
            await _personRepo.CreateNewPerson(person);
        }

        public async Task DeletePersonById(int id)
        {
            await _personRepo.DeletePersonById(id);
        }

        public async Task<Person> GetActivePersonById(int id)
        {
            return await _personRepo.GetActivePersonById(id);
        }

        public IQueryable<PersonDTO> GetAllActivePersons()
        {
            var persons = _personRepo.GetAllActivePersons();
            return persons.Select(person => new PersonDTO
            {
                PersonID = person.PersonID,
                FullName = person.FullName,
                Title = person.Title,
                Description = person.Description,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                CategoryID = person.CategoryID,
                IsActive = person.IsActive,
                CategoryName = person.Category.CategoryName
            });
        }

        public IQueryable<PersonDTO> GetAllInactivePersons()
        {
            var persons = _personRepo.GetAllInactivePersons();
            return persons.Select(person => new PersonDTO
            {
                PersonID = person.PersonID,
                FullName = person.FullName,
                Title = person.Title,
                Description = person.Description,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                CategoryID = person.CategoryID,
                IsActive = person.IsActive,
                CategoryName = person.Category.CategoryName
            });
        }

        public async Task UpdatePerson(PersonDTO person)
        {
            await _personRepo.UpdatePerson(person);
        }
    }
}
