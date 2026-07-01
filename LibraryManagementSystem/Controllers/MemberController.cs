using LibraryManagementSystem.CQRS.Members.Commands;
using LibraryManagementSystem.CQRS.Members.Queries;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var member = await _mediator.Send(new GetAllMemberQuery());
            return Ok(member);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var member = await _mediator.Send(new GetMemberByIdQuery(id));
            if (member is null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand command)
        {
            var member = await _mediator.Send(command);
            return Ok(member);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update(int id, UpdateMemberCommand command)
        {
            command.Id = id;
            var member = await _mediator.Send(command);
            if (member is null) return NotFound();
            return Ok(member);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var member = await _mediator.Send(new DeleteMemberCommand(id));
            if (member is null) return NotFound();
            return Ok(member);
        }
    }
}



