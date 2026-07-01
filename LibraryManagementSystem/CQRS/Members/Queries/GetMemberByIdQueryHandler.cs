using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Queries
{
    public class GetMemberByIdQueryHandler:IRequestHandler<GetMemberByIdQuery,Member?>
    {
        private readonly IMemberRepository _repository;

        public GetMemberByIdQueryHandler(IMemberRepository memberRepository)
        {
            _repository = memberRepository;
        }

        public async Task<Member?> Handle(
            GetMemberByIdQuery request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.GetMemberById(request.Id);
        }
    }
}
