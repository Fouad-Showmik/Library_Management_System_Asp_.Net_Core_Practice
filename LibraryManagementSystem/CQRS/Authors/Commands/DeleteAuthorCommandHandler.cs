using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Commands
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Author?>
    {
        private readonly IAuthorRepository _repository;

        public DeleteAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Author?> Handle(
            DeleteAuthorCommand request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
