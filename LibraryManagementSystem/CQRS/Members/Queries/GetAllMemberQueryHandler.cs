using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Queries
{
    public class GetAllMemberQueryHandler:IRequestHandler<GetAllMemberQuery, List<Member>>
    {
        private readonly IMemberRepository _repository;

        public GetAllMemberQueryHandler(IMemberRepository memberRepository)
        {
            _repository = memberRepository;
        }

        public async Task<List<Member>> Handle(
            GetAllMemberQuery request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.GetAllMembers();
        }
    }
}
