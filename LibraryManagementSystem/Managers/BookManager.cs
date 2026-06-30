using LibraryManagementSystem.Managers.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;

namespace LibraryManagementSystem.Managers
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateBook(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                AuthorId = dto.AuthorId,
                CategoryId = dto.CategoryId,
                AvailableCopies = dto.AvailableCopies,
                TotalCopies = dto.TotalCopies,
            };

            return await _bookRepository.CreateBook(book);
        }

        public async Task<Book?> DeleteBook(int id)
        {
           return await _bookRepository.DeleteBook(id);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public Task<Book?> GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public async Task<Book?> UpdateBook(int id, BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                AuthorId = dto.AuthorId,
                CategoryId = dto.CategoryId,
                AvailableCopies = dto.AvailableCopies,
                TotalCopies = dto.TotalCopies,
            };
            return await _bookRepository.UpdateBook(id, book);
        }
    }
}
