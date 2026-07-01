using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Queries
{
    public class GetAllMemberQuery : IRequest<List<Member>>
    {
    }
}
