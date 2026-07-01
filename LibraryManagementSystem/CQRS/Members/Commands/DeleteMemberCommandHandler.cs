using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repositories.Interfaces;
using MediatR;

namespace LibraryManagementSystem.CQRS.Members.Commands
{
    public class DeleteMemberCommandHandler:IRequestHandler<DeleteMemberCommand,Member?>
    {
        private readonly IMemberRepository _repository;

        public DeleteMemberCommandHandler(IMemberRepository memberRepository)
        {
            _repository = memberRepository;
        }

        public async Task<Member?> Handle(
            DeleteMemberCommand request,
            CancellationToken cancellationToken
            )
        {
            return await _repository.DeleteMember(request.Id);
        }
    }
}
