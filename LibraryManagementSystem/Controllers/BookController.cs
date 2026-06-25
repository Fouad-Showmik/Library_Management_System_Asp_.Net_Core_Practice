using LibraryManagementSystem.Data;
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
        private readonly ApplicationDbContext dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllBook()
        {
            var res = await dbContext.Books.ToListAsync();
            return Ok(res);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBook(BookDto book)
        {
            var newBook = new Book() { 
                Title = book.Title,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                AvailableCopies = book.AvailableCopies,
                TotalCopies = book.TotalCopies,
            };

            await dbContext.Books.AddAsync(newBook);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateBookAsync(int id, BookDto book)
        {
            var res = await dbContext.Books.FindAsync(id);
            if (res is null) return NotFound();
            

            res.Title = book.Title;
            res.ISBN = book.ISBN;
            res.AuthorId = book.AuthorId;
            res.CategoryId = book.CategoryId;
            res.AvailableCopies = book.AvailableCopies;
            res.TotalCopies = book.TotalCopies;

            await dbContext.SaveChangesAsync();
            return Ok(res);


        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteBook(int id)
        {
            var res = dbContext.Books.Find(id);
            if(res is null)
            {
                return NotFound();
            }
            dbContext.Books.Remove(res);
            dbContext.SaveChanges();
            return Ok($"{res.Title} deleted successfully.");
        }
    }
}
