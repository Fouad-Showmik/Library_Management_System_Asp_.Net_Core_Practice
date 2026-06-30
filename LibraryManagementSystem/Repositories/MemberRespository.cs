using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRespository:IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRespository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Member> CreateMember(Member member)
        {
            var existing = new Member
            {
                FullName = member.FullName,
                Email = member.Email,
                Phone = member.Phone,
            };

            await _context.Members.AddAsync(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Member?> DeleteMember(int id)
        {
            var existing = await _context.Members.FindAsync(id);
            if (existing is null) return null;
            return existing;
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _context.Members.Include(a => a.BorrowRecords).ToListAsync();
        }
        

        public async Task<Member?> GetMemberById(int id)
        {
            var existing = await _context.Members.Include(a => a.BorrowRecords).FirstOrDefaultAsync(a => a.Id == id);
            if (existing is null) return null;

            return existing;
        }

        public async Task<Member?> UpdateMember(int id, Member member)
        {
            var existing = await _context.Members.FindAsync(id);
            if (existing is null) return null;

            existing.FullName = member.FullName;
            existing.Email = member.Email;
            existing.Phone = member.Phone;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
