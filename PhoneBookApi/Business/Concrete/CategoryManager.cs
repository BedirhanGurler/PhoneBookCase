using PhoneBookApi.Business.Abstract;
using PhoneBookApi.DataAccess.EFCoreBase.Abstract;
using PhoneBookApi.Models.Concrete;

namespace PhoneBookApi.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryManager(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task AddCategory(Category category)
        {
            await _categoryRepo.AddCategory(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepo.DeleteCategory(id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepo.GetAllAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            await _categoryRepo.UpdateCategory(category);
        }
    }
}
