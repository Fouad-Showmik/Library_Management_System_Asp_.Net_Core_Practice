using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public BorrowRecordRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<BorrowRecord> CreateAsync(BorrowRecord borrowRecord)
        {
            var existing = new BorrowRecord
            {
                BorrowDate = borrowRecord.BorrowDate,
                ReturnDate = borrowRecord.ReturnDate,
                BookId = borrowRecord.BookId,
                MemberId = borrowRecord.MemberId,
                IsReturned = borrowRecord.IsReturned,
                
            };

            await _context.BorrowRecords.AddAsync(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<BorrowRecord?> DeleteAsync(int id)
        {
            var existing = await _context.BorrowRecords.FindAsync(id);
            if (existing is null) return null;
            return existing;
        }

        public async Task<List<BorrowRecord>> GetAllAsync()
        {
            return await _context.BorrowRecords.ToListAsync();
        }

        public async Task<BorrowRecord?> GetByIdAsync(int id)
        {
            var existing = await _context.BorrowRecords.FindAsync(id);
            if (existing is null) return null;

            return existing;
        }

        public async Task<BorrowRecord?> UpdateAsync(int id, BorrowRecord borrowRecord)
        {
            var existing = await _context.BorrowRecords.FindAsync(id);
            if (existing is null) return null;

            existing.BookId = borrowRecord.BookId;
            existing.MemberId = borrowRecord.MemberId;
            existing.BorrowDate = borrowRecord.BorrowDate;
            existing.ReturnDate = borrowRecord.ReturnDate;
            existing.IsReturned = borrowRecord.IsReturned;

            await _context.SaveChangesAsync();
            return existing;
        }

    }
}
