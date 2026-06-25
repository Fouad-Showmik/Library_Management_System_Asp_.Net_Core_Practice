using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Models
{
    public class AuthorDto
    {

        public required string Name { get; set; }
        public string? Bio { get; set; }
    }
}

