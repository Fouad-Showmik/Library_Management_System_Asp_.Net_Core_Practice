using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/borrowRecord")]
    [ApiController]
    public class BorrowRecordController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BorrowRecordController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllRecord()
        {
            var res = await dbContext.BorrowRecords.ToListAsync();

            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetSingleRecord(int id)
        {
            var res = await dbContext.BorrowRecords.FindAsync(id);

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

        public async Task<IActionResult> CreateRecord(BorrowRecordDto dto)
        {
            var res = new BorrowRecord()
            {
                MemberId = dto.MemberId,
                BookId = dto.BookId,
                BorrowDate = dto.BorrowDate,
                ReturnDate = dto.ReturnDate,
                IsReturned = dto.IsReturned,
            };

            await dbContext.BorrowRecords.AddAsync(res);
            dbContext.SaveChanges();
            return Ok(res);
        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateRecord(int id,  BorrowRecordDto dto)
        {
            var res = await dbContext.BorrowRecords.FindAsync(id);
            if(res is null)
            {
                return NotFound();
            }

            res.MemberId = dto.MemberId;
            res.BookId = dto.BookId;
            res.BorrowDate = dto.BorrowDate;
            res.ReturnDate = dto.ReturnDate;
            res.IsReturned = dto.IsReturned;

            dbContext.SaveChanges();
            return Ok(res);
        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteRecord(int id)
        {
            var res = await dbContext.BorrowRecords.FindAsync(id);

            if (res is null)
            {
                return NotFound();
            }

            dbContext.BorrowRecords.Remove(res);
            dbContext.SaveChanges();
            return Ok($"{res.MemberId} deleted successfully.");
        }

    }
}
