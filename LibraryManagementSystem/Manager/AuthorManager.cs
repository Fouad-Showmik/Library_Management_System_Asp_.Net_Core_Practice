using LibraryManagementSystem.Manager.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Repositories.Interfaces;

namespace LibraryManagementSystem.Manager
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync(AuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                Bio = dto.Bio,
            };
            return await _authorRepository.CreateAsync(author);
        }

        public async Task<Author?> DeleteAsync(int id)
        {
            return await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
           return await _authorRepository.GetByIdAsync(id);
        }

        public async Task<Author?> UpdateAsync(int id, AuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name,
                Bio = dto.Bio,
            };

            return await _authorRepository.UpdateAsync(id,author);
        }
    }
}
