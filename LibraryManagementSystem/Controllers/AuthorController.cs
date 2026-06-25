using LibraryManagementSystem.Data;
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
        private readonly ApplicationDbContext dbcontext;

        public AuthorController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAuthor()
        {
            var res = await dbcontext.Authors.Include(a => a.Books).
                ToListAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetAuthorByID(int id)
        {
            var res = await dbcontext.Authors.FindAsync(id);
            if(res is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPost]

        public async Task<IActionResult> CreateAuthor(AuthorDto author)
        {

            var authorCreate = new Author()
            {
                Bio = author.Bio,
                Name = author.Name,
            };

            dbcontext.Authors.Add(authorCreate);
            dbcontext.SaveChanges();
            return Ok(authorCreate);

        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateAuthor(int id, AuthorDto author)
        {
            var res = await dbcontext.Authors.FindAsync(id);
            if(res is null)
            {
                return NotFound();
            }

            res.Name = author.Name;
            res.Bio = author.Bio;
            dbcontext.SaveChanges();
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var res = await dbcontext.Authors.FindAsync(id);

            if(res is null)
            {
                return NotFound();
            }

            dbcontext.Authors.Remove(res);
            dbcontext.SaveChanges();
            return Ok($"{res.Name} deleted successfully.");
        }
    }
    


}
