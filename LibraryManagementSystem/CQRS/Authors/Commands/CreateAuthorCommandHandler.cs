using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Commands
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _repository;

        public CreateAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Author> Handle(
            CreateAuthorCommand request,
            CancellationToken cancellationToken
            )
        {
            var author = new Author
            {
            Name = request.Name,
            Bio = request.Bio,
            };

            return await _repository.CreateAsync(author);
        }
    }
}
