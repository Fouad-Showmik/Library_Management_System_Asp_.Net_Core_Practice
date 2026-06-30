using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Managers.Interfaces
{
    public interface IBorrowRecordManager
    {
        Task<List<BorrowRecord>> GetAllAsync();
        Task<BorrowRecord?> GetByIdAsync(int id);
        Task<BorrowRecord> CreateAsync(BorrowRecordDto dto);
        Task<BorrowRecord?> UpdateAsync(int id, BorrowRecordDto dto);
        Task<BorrowRecord?> DeleteAsync(int id);
    }
}
