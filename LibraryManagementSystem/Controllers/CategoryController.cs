using LibraryManagementSystem.Data;
using LibraryManagementSystem.Managers.Interfaces;
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
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryManager.GetAllCategory();
            return Ok(category);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var author = await _categoryManager.GetCategoryById(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            var author = await _categoryManager.CreateCategory(dto);
            return Ok(author);
        }

        [HttpPut]

        public async Task<IActionResult> Update(int id, CategoryDto dto)
        {
            var author = await _categoryManager.UpdateCategory(id, dto);
            if (author is null) return NotFound();
            return Ok(author);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var author = await _categoryManager.DeleteCategory(id);
            if (author is null) return NotFound();
            return Ok(author);

        }

    }
}
