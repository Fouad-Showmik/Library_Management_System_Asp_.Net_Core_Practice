using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Repositories.Interfaces;

namespace LibraryManagementSystem.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();

            return services;
        }
    }
}
