using LibraryManagementSystem.Manager;
using LibraryManagementSystem.Manager.Interfaces;
using LibraryManagementSystem.Managers;
using LibraryManagementSystem.Managers.Interfaces;

namespace LibraryManagementSystem.Extensions
{
    public static class ManagerExtensions
    {
        public static IServiceCollection AddManagers(this IServiceCollection services) {

            services.AddScoped<IAuthorManager, AuthorManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IBookManager, BookManager>();
            services.AddScoped<IMemberManager, MemberManager>();
            services.AddScoped<IBorrowRecordManager, BorrowRecordManager>();

            return services;
        }
    }
}
