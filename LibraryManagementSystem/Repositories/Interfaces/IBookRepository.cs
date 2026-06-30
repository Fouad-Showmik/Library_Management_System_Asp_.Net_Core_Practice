using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book> CreateBook(Book book);
        Task<Book?> UpdateBook(int id, Book book);
        Task <Book?> DeleteBook(int id);
    }
}
