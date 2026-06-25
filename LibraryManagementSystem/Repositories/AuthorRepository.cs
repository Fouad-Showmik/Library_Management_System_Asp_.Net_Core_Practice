using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
           _context = context;
        }


        //Get All
        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        //Get by Id
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }

        //Create Author
        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        //Update Auhtor
        public async Task<Author?> UpdateAsync(int id, Author author)
        {
            var existing = await _context.Authors.FindAsync(id);
            if (existing is null) return null;

            existing.Name = author.Name;
            existing.Bio = author.Bio;

            await _context.SaveChangesAsync();
            return existing;
        }

        //Delete Author
        public async Task<Author?> DeleteAsync(int id)
        {
            var existing = await _context.Authors.FindAsync(id);
            if (existing is null) return null;

             _context.Authors.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }


    }
}
