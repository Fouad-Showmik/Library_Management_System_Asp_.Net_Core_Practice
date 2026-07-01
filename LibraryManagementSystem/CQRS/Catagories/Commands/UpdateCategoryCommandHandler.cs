using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Catagories.Commands
{
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommand, Category?>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<Category?> Handle (
            UpdateCategoryCommand request,
            CancellationToken cancellationToken
            )
        {
            var existing = await _repository.GetCategoryById(request.Id);

            if (existing is null) return null;

            existing.Name = request.Name ?? existing.Name;

            return await _repository.UpdateCategory(existing);
        }
    }
}
