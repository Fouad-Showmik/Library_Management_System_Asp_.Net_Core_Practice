using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Queries
{
    public class GetAllAuthorsQuery : IRequest<List<Author>> 
    {
    }
}
