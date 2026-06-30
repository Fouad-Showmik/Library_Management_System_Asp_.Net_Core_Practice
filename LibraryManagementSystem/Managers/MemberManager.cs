using LibraryManagementSystem.Managers.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using System.Linq.Expressions;

namespace LibraryManagementSystem.Managers
{
    public class MemberManager:IMemberManager
    {
        private readonly IMemberRepository _memberRepository;

        public MemberManager(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> CreateMember(MemberDto dto)
        {
            var member = new Member { 
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
            };
            return await _memberRepository.CreateMember(member);
        }

        public Task<Member?> DeleteMember(int id)
        {
           return _memberRepository.DeleteMember(id);
        }

        public async Task<List<Member>> GetAllMember()
        {
           return await _memberRepository.GetAllMembers();
        }

        public Task<Member?> GetMemberById(int id)
        {
            return _memberRepository.GetMemberById(id);
        }

        public async Task<Member?> UpdateMember(int id, MemberDto dto)
        {
            var member = new Member {
                FullName= dto.FullName,
                Email= dto.Email,
                Phone= dto.Phone,
            };

            return await _memberRepository.UpdateMember(id, member);
        }
    }
}
