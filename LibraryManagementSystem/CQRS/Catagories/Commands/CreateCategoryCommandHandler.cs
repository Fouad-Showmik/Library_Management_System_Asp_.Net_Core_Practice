using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Catagories.Commands
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,Category>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<Category> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken
            )
        {
            var category = new Category
            {
                Name = request.Name
            };

            return await _repository.CreateCategory(category);
        }
    }
}
