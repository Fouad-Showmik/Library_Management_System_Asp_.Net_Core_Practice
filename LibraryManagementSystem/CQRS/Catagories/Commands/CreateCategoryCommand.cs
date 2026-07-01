using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Catagories.Commands
{
    public class CreateCategoryCommand:IRequest<Category>
    {
        public required string Name { get; set; }
    }
}
