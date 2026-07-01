using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Books.Commands
{
    public class DeleteBookCommnadHandler:IRequestHandler<DeleteBookCommnad, Book?>
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommnadHandler(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        public async Task<Book?> Handle(
            DeleteBookCommnad request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.DeleteBook(request.Id);
        }
    }
}
