using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Commands
{
    public class DeleteAuthorCommand : IRequest <Author?>
    {
        public int Id { get; set; }

        public DeleteAuthorCommand(int id)
        {
            Id = id;
        }
    }
}
