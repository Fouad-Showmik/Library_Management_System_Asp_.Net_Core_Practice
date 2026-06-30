using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Commands
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author?>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Author?> Handle(
            UpdateAuthorCommand request,
            CancellationToken cancellationToken
            )
        {
            var author = new Author
            {
                Name = request.Name,
                Bio = request.Bio,
            };
            return await _authorRepository.UpdateAsync(request.Id, author);
        }
    }
}
