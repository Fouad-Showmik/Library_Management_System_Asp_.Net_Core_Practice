using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Books.Queries
{
    public class GetAllBookQueryHandler:IRequestHandler<GetAllBookQuery, List<Book>>
    {
        private readonly IBookRepository _repository;

        public GetAllBookQueryHandler(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        public async Task<List<Book>> Handle(
            GetAllBookQuery request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.GetAllBooks();
        }
    }
}
