using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Catagories.Queries
{
    public class GetAllCategoryQueryHandler:IRequestHandler<GetAllCategoryQuery,List<Category>>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<List<Category>> Handle(
            GetAllCategoryQuery request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.GetAllCategory();
        }
    }
}
