using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
