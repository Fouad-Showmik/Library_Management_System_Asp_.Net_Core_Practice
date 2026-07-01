using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Catagories.Commands
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand, Category?>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _repository  = categoryRepository;
        }

        public async Task<Category?> Handle(
            DeleteCategoryCommand request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.DeleteCategory(request.Id);
        }
    }
}
