using LibraryManagementSystem.Data;
using LibraryManagementSystem.Managers.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var book = await _bookManager.GetAllBooks();
            return Ok(book);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookManager.GetBookById(id);
            if(book is null) return NotFound();
            return Ok(book);
        }

        [HttpPost]

        public async Task<IActionResult> Create(BookDto dto)
        {
            var book = await _bookManager.CreateBook(dto);
            return Ok(book);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update(int id,BookDto dto) {
            var book = await _bookManager.UpdateBook(id, dto);
            if (book is null) return NotFound();
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Delete(int id) {
        var book = _bookManager.DeleteBook(id);
            if(book is null) return NotFound(); 
            return Ok(book);
        }
    }
}
