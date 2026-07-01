using LibraryManagementSystem.Models.Entities;
using MediatR;

namespace LibraryManagementSystem.CQRS.Catagories.Queries
{
    public class GetAllCategoryQuery:IRequest<List<Category?>>
    {
    }
}
