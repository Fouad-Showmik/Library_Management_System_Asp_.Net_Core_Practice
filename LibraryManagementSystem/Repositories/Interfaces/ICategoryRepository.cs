using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
         Task<List<Category>> GetAllCategory();
         Task<Category?> GetCategoryById(int id);
         Task<Category> CreateCategory(Category category);
         Task<Category?> UpdateCategory(int id, Category category);
         Task<Category?> DeleteCategory(int id);
    }
}
