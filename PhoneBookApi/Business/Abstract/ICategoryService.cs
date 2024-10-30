using PhoneBookApi.Models.Concrete;

namespace PhoneBookApi.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
