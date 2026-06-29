using LibraryManagementSystem.Data;
using LibraryManagementSystem.Manager.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{   //localhost:xxxx/api/author
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager context)
        {
            _authorManager = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorManager.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorManager.GetByIdAsync(id);
            return Ok(author);
        }

        [HttpPost]

        public async Task<IActionResult> Create(AuthorDto dto)
        {
            var auhtors = await _authorManager.CreateAsync(dto);
            return Ok(auhtors);

        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update(int id, AuthorDto dto)
        {
            var authors = await _authorManager.UpdateAsync(id, dto);
            if (authors is null) return NotFound();
            return Ok(authors);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var auhtor = await _authorManager.DeleteAsync(id);
            if (auhtor is null) return NotFound();
            return Ok(auhtor);
        }

    }
}
