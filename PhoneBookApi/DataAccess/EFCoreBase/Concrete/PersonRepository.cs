using Microsoft.EntityFrameworkCore;
using PhoneBookApi.DataAccess.EFCoreBase.Abstract;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.DataAccess.EFCoreBase.Concrete
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDBContext _dbContext;
        public PersonRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNewPerson(PersonDTO personDto)
        {
            var person = new Person
            {
                FullName = personDto.FullName,
                Title = personDto.Title,
                Description = personDto.Description,
                PhoneNumber = personDto.PhoneNumber,
                Email = personDto.Email,
                CategoryID = personDto.CategoryID,
                IsActive = personDto.IsActive
            };
            await _dbContext.AddAsync(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePersonById(int id)
        {
            var person = await _dbContext.Persons.FindAsync(id);
            if (person != null)
            {
                _dbContext.Persons.Remove(person);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Person?> GetActivePersonById(int id)
        {
            return await _dbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id && p.IsActive);
        }

        public IQueryable<Person> GetAllActivePersons()
        {
            return _dbContext.Persons.Include(p => p.Category).Where(p => p.IsActive);
        }

        public async Task UpdatePerson(PersonDTO personDto)
        {
            var existingPerson = await _dbContext.Persons.FindAsync(personDto.PersonID); // Assuming PersonID is the key

            if (existingPerson == null)
            {
                throw new InvalidOperationException("Person not found.");
            }

            existingPerson.FullName = personDto.FullName;
            existingPerson.PhoneNumber = personDto.PhoneNumber;
            existingPerson.Email = personDto.Email;
            existingPerson.Title = personDto.Title;
            existingPerson.Description = personDto.Description;
            existingPerson.CategoryID = personDto.CategoryID;
            existingPerson.IsActive = personDto.IsActive;
            _dbContext.Update(existingPerson);
            await _dbContext.SaveChangesAsync();
        }
    }
}
