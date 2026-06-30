using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IBorrowRecordRepository
    {
        Task<List<BorrowRecord>> GetAllAsync();
        Task<BorrowRecord?> GetByIdAsync(int id);
        Task<BorrowRecord> CreateAsync(BorrowRecord borrowRecord);
        Task<BorrowRecord?> UpdateAsync(int id, BorrowRecord borrowRecord);
        Task<BorrowRecord?> DeleteAsync(int id);
    }
}
