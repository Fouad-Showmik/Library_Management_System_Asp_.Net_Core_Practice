using LibraryManagementSystem.Models.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.CQRS.Books.Commands
{
    public class UpdateBookCommand:IRequest<Book?>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public  string? Title { get; set; }
        public string? ISBN { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int? TotalCopies { get; set; }
        public int? AvailableCopies { get; set; }
    }
}
