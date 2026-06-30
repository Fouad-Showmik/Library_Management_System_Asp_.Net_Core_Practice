using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMembers();
        Task<Member?> GetMemberById(int id);
        Task<Member> CreateMember(Member member);
        Task<Member?> UpdateMember(int id, Member member);
        Task<Member?> DeleteMember(int id);
    }
}
