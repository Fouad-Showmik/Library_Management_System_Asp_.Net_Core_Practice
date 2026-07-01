using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Books.Commands
{
    public class DeleteBookCommnad:IRequest<Book?>
    {
        public int Id { get; set; }

        public DeleteBookCommnad(int id)
        {
            Id = id;
        }
    }
}
