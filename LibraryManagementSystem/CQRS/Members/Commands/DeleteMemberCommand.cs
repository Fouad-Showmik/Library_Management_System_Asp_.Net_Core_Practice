using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Commands
{
    public class DeleteMemberCommand:IRequest<Member?>
    {
        public int Id {  get; set; }

        public DeleteMemberCommand(int id)
        {
            Id = id;
        }
    }
}
