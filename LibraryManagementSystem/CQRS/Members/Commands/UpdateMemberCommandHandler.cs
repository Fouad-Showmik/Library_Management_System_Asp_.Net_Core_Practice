using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Commands
{
    public class UpdateMemberCommandHandler:IRequestHandler<UpdateMemberCommand, Member?>
    {
        private readonly IMemberRepository _repository;

        public UpdateMemberCommandHandler(IMemberRepository memberRepository)
        {
            _repository = memberRepository;
        }

        public async Task<Member?> Handle(
            UpdateMemberCommand request,
            CancellationToken cancellationToken
            )
        {
            var member = new Member
            {
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
            };
            return await _repository.UpdateMember(request.Id,member);
        }
}
}
