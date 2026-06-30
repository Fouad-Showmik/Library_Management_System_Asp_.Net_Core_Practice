using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;
using System.Reflection.Metadata;

namespace LibraryManagementSystem.CQRS.Authors.Queries
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author?>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorByIdQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Author?> Handle(
            GetAuthorByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
            
    }

}
