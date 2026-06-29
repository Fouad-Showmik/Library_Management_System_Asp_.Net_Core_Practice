using LibraryManagementSystem.Managers.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;

namespace LibraryManagementSystem.Managers
{
    public class CategoryManager: ICategoryManager

    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategory(CategoryDto dto)
        {
            var catergory = new Category
            {
                Name = dto.Name
            };

            return await _categoryRepository.CreateCategory(catergory);

        }

        public async Task<Category?> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task<Category?> UpdateCategory(int id, CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            return await _categoryRepository.UpdateCategory(id, category);
        }
    }
}
