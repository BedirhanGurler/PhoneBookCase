using PhoneBookApi.Models.Concrete;

namespace PhoneBookApi.DataAccess.EFCoreBase.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
