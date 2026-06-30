using LibraryManagementSystem.Managers.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;

namespace LibraryManagementSystem.Managers
{
    public class BorrowRecordManager:IBorrowRecordManager
    {
        private readonly IBorrowRecordRepository _borrowRecordRepository;

        public BorrowRecordManager(IBorrowRecordRepository borrowRecordRepository)
        {
            _borrowRecordRepository = borrowRecordRepository;
        }

        public async Task<BorrowRecord> CreateAsync(BorrowRecordDto dto)
        {
            var existing = new BorrowRecord
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                BorrowDate = dto.BorrowDate,
                ReturnDate = dto.ReturnDate,
                IsReturned = dto.IsReturned,
            };
            return await _borrowRecordRepository.CreateAsync(existing);
        }

        public async Task<BorrowRecord?> DeleteAsync(int id)
        {
            return await _borrowRecordRepository.DeleteAsync(id);
        }

        public Task<List<BorrowRecord>> GetAllAsync()
        {
            return _borrowRecordRepository.GetAllAsync();
        }

        public async Task<BorrowRecord?> GetByIdAsync(int id)
        {
            return await _borrowRecordRepository.GetByIdAsync(id);
        }

        public async Task<BorrowRecord?> UpdateAsync(int id, BorrowRecordDto dto)
        {
            var existing = new BorrowRecord
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                BorrowDate = dto.BorrowDate,
                ReturnDate = dto.ReturnDate,
                IsReturned = dto.IsReturned,
            };
            return await _borrowRecordRepository.UpdateAsync(id, existing);
        }
    }
}
