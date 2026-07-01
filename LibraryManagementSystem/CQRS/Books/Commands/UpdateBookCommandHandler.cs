using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Books.Commands
{
    public class UpdateBookCommandHandler:IRequestHandler<UpdateBookCommand,Book?>
    {
        private readonly IBookRepository _repository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        public async Task<Book?> Handle(
            UpdateBookCommand request,
            CancellationToken cancellationToken
            )
        {
            var existing = await _repository.GetBookById(request.Id);
            if (existing is null) return null;

            existing.Title = request.Title ?? existing.Title;
            existing.ISBN = request.ISBN ?? existing.ISBN;
            existing.AuthorId = request.AuthorId ?? existing.AuthorId;
            existing.CategoryId = request.CategoryId ?? existing.CategoryId;
            existing.AvailableCopies = request.AvailableCopies ?? existing.AvailableCopies;
            existing.TotalCopies = request.TotalCopies ?? existing.TotalCopies;

            return await _repository.UpdateBook(request.Id, existing);
        }
    }
}
