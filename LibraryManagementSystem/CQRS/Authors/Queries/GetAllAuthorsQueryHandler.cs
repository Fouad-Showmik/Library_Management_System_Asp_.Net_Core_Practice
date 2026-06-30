using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Queries
{
    public class GetAllAuthorsQueryHandler: IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly IAuthorRepository _repository;

        public GetAllAuthorsQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Author>> Handle(
            GetAllAuthorsQuery request,
            CancellationToken cancellation)
        {
            return await _repository.GetAllAsync();
        }
    }
}
