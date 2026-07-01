using LibraryManagementSystem.CQRS.Catagories.Commands;
using LibraryManagementSystem.CQRS.Catagories.Queries;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(category);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var author = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var author = await _mediator.Send(command);
            return Ok(author);
        }

        [HttpPut]

        public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
        {   
            command.Id = id;
            var author = await _mediator.Send(command);
            if(author is null) return NotFound();
            return Ok(author);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var author = await _mediator.Send(new DeleteCategoryCommand(id));
            if (author is null) return NotFound();
            return Ok(author);

        }

    }
}
