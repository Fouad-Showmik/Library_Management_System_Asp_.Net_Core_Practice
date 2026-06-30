using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Commands
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public required string Name { get; set; }
        public string? Bio {  get; set; }
    }
}
