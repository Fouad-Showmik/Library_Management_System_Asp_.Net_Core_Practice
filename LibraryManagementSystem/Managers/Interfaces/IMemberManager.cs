using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Managers.Interfaces
{
    public interface IMemberManager
    {
        Task<List<Member>> GetAllMember();
        Task<Member?> GetMemberById(int id);
        Task<Member> CreateMember(MemberDto dto);
        Task<Member?> UpdateMember(int id, MemberDto dto);
        Task<Member?> DeleteMember(int id);
    }
}
