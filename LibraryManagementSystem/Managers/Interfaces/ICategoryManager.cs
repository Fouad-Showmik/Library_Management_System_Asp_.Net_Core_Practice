using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Managers.Interfaces
{
    public interface ICategoryManager
    {
        Task<List<Category>> GetAllCategory();
        Task<Category?> GetCategoryById(int id);
        Task<Category> CreateCategory(CategoryDto dto);
        Task<Category?> UpdateCategory(int id, CategoryDto dto);
        Task<Category?> DeleteCategory(int id);
    }
}
