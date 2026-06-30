using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Authors.Commands
{
    public class UpdateAuthorCommand : IRequest <Author?>
    {
        public int Id { get; set; }
        public required string Name {  get; set; }

        public string? Bio {  get; set; }
    }
}
