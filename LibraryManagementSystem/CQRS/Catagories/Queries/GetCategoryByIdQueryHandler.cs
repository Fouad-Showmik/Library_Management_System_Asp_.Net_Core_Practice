using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Catagories.Queries
{
    public class GetCategoryByIdQueryHandler:IRequestHandler<GetCategoryByIdQuery,Category?>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<Category?> Handle(
            GetCategoryByIdQuery request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.GetCategoryById(request.Id);
        }
    }
}
