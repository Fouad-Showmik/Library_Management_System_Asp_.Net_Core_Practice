using LibraryManagementSystem.CQRS.Books.Commands;
using LibraryManagementSystem.CQRS.Books.Queries;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var book = await _mediator.Send(new GetAllBookQuery());
            return Ok(book);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            if(book is null) return NotFound();
            return Ok(book);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            var book = await _mediator.Send(command);
            return Ok(book);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update(int id,UpdateBookCommand command) {

            command.Id = id;
            var book = await _mediator.Send(command);
            if (book is null) return NotFound();
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete(int id) {
            var book = await _mediator.Send(new DeleteBookCommnad(id));
            if(book is null) return NotFound(); 
            return Ok(book);
        }
    }
}
