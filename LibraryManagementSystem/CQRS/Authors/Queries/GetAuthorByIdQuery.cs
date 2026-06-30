using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Queries
{
    public class GetAuthorByIdQuery : IRequest<Author?>
    {
        public int Id { get; set; }
        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
