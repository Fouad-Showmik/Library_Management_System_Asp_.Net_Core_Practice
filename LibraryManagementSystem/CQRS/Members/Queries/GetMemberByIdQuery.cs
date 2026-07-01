using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Queries
{
    public class GetMemberByIdQuery:IRequest<Member?>
    {
        public int Id { get; set; }

        public GetMemberByIdQuery(int id)
        {
            Id = id;
        }
    }
}
