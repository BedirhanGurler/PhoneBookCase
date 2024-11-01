using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.DataAccess.EFCoreBase.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
