using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Book> CreateBook(Book book)
        {
            var existing = new Book
            {
                Title = book.Title,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies,
            };

            await _context.Books.AddAsync(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Book?> DeleteBook(int id)
        {
            var existing = await _context.Books.FindAsync(id);
            if (existing is null) return null;
            return existing;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
            var existing = await _context.Books.FindAsync(id);
            if (existing is null) return null;

            return existing;
        }

        public async Task<Book?> UpdateBook(int id, Book book)
        {
            var existing = await _context.Books.FindAsync(id);
            if (existing is null) return null;

            existing.Title = book.Title;
            existing.ISBN = book.ISBN;
            existing.AuthorId = book.AuthorId;
            existing.CategoryId = book.CategoryId;
            existing.AvailableCopies = book.AvailableCopies;
            existing.TotalCopies = book.TotalCopies;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
