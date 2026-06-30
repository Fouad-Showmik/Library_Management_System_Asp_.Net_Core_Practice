using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Managers.Interfaces
{
    public interface IBookManager
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book> CreateBook(BookDto dto);
        Task<Book?> UpdateBook(int id, BookDto dto);
        Task<Book?> DeleteBook(int id);
    }
}
