using LibraryManagementSystem.Models.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace LibraryManagementSystem.CQRS.Catagories.Commands
{
    public class UpdateCategoryCommand:IRequest<Category?>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
