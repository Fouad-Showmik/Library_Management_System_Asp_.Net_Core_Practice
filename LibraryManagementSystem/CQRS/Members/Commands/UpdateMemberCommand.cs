using LibraryManagementSystem.Models.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.CQRS.Members.Commands
{
    public class UpdateMemberCommand:IRequest<Member?>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
