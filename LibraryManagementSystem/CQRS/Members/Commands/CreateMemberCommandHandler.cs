using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Commands
{
    public class CreateMemberCommandHandler:IRequestHandler<CreateMemberCommand,Member>
    {
        private readonly IMemberRepository _repository;

        public CreateMemberCommandHandler(IMemberRepository memberRepository)
        {
            _repository = memberRepository;
        }

        public async Task<Member> Handle(
            CreateMemberCommand request,
            CancellationToken cancellationToken
            )
        {
            var member = new Member
            {
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
            };

            return await _repository.CreateMember(member);
        }
    }
}
