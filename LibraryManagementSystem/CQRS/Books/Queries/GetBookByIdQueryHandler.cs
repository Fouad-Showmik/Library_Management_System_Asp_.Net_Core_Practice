using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Books.Queries
{
    public class GetBookByIdQueryHandler:IRequestHandler<GetBookByIdQuery,Book?>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        public async Task<Book?> Handle(
            GetBookByIdQuery request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.GetBookById(request.Id);
        }
    }
}
