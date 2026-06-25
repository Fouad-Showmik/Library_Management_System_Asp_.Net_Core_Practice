using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Manager.Interfaces
{
    public interface IAuthorManager
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> CreateAsync(AuthorDto dto);
        Task<Author?> UpdateAsync(int id, AuthorDto dto);
        Task<Author?> DeleteAsync(int id);
    }
}
