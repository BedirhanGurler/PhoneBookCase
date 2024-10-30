using Microsoft.EntityFrameworkCore;
using PhoneBookApi.DataAccess.EFCoreBase.Abstract;
using PhoneBookApi.Models.Concrete;

namespace PhoneBookApi.DataAccess.EFCoreBase.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _dbContext;
        public CategoryRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCategory(Category category)
        {
            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if(category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _dbContext.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
