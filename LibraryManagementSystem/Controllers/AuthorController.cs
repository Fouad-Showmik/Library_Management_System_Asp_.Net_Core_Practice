using LibraryManagementSystem.CQRS.Authors.Commands;
using LibraryManagementSystem.CQRS.Authors.Queries;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{   //localhost:xxxx/api/author
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (author is null) return NotFound();
            return Ok(author);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateAuthorCommand command)
        {
            var auhtors = await _mediator.Send(command);
            return Ok(auhtors);

        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update(int id, UpdateAuthorCommand command)
        {
            command.Id = id;
            var author = _mediator.Send(command);
            if (author is null) return NotFound();
            return Ok(author);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _mediator.Send(new DeleteAuthorCommand(id));
            if (author is null) return NotFound();
            return Ok($"{author.Name} deleted successfully.");
        }
    }
}
