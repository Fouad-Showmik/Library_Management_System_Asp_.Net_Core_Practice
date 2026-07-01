using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Books.Commands
{
    public class CreateBookCommandHandler:IRequestHandler<CreateBookCommand,Book>
    {
        private readonly IBookRepository _repository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        public async Task<Book> Handle(
            CreateBookCommand request,
            CancellationToken cancellationToken
            )
        {
            var book = new Book
            {
                Title = request.Title,
                ISBN = request.ISBN,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                AvailableCopies = request.AvailableCopies,
                TotalCopies = request.TotalCopies,
            };
            return await _repository.CreateBook(book);
        }
    }
}
