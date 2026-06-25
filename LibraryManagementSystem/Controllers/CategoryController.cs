using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            var res = await dbContext.Categories.ToListAsync();
            return Ok(res);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategoryAsync(CategoryDto category)
        {
            var addCategory = new Category()
            {
                Name = category.Name,
            };

            await dbContext.Categories.AddAsync(addCategory);
            dbContext.SaveChanges();
            return Ok(addCategory);
        }

        [HttpPatch]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateCategory(int id, CategoryDto category)
        {
            var res = await dbContext.Categories.FindAsync(id);
            if (res is null)
            {
                return NotFound();
            }
            else
            {
                res.Name = category.Name;
            }

            dbContext.SaveChanges();
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var res = await dbContext.Categories.FindAsync(id);

            if(res is not null)
            {
                dbContext.Categories.Remove(res);
                dbContext.SaveChanges();
                return Ok($"{res.Name} deleted successfully.");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
