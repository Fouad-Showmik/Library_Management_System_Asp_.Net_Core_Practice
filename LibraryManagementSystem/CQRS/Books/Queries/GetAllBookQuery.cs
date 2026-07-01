using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Books.Queries
{
    public class GetAllBookQuery:IRequest<List<Book>>
    {
    }
}
