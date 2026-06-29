using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.Categories.Include(a => a.Books).ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> UpdateCategory(int id, Category category)
        {
            var existing = await _context.Categories.FindAsync(id);
            if (existing is null) return null;

            existing.Name = category.Name;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var existing = await _context.Categories.FindAsync(id);
            if (existing is null) return null;

             _context.Categories.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
