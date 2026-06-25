using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MemberController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet] 

        public async Task<IActionResult> GetAllMembersAsync()
        {
            var res = await dbContext.Members.Include(a => a.BorrowRecords).ToListAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetSingleMember(int id)
        {
            var res = await dbContext.Members.FindAsync(id);
                if (res is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }

        }

        [HttpPost]

        public async Task<IActionResult> CreatMember(MemberDto dto)
        {
            var res = new Member()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
            };

            await dbContext.Members.AddAsync(res);
            dbContext.SaveChanges();
            return Ok(res);
        }


        [HttpPatch]
        [Route("{id:int}")]

        public async Task<IActionResult> UpdateMember(int id, MemberDto dto)
        {
            var res = await dbContext.Members.FindAsync(id);
            if (res is null)
            {
                return NotFound();
            }

            res.FullName = dto.FullName;
            res.Email = dto.Email;
            res.Phone = dto.Phone;

            dbContext.SaveChanges();
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteMember(int id)
        {
            var res = await dbContext.Members.FindAsync(id);

            if (res is null)
            {
                NotFound();
            }

            dbContext.Members.Remove(res);
            dbContext.SaveChanges();
            return Ok($"{res.FullName} deleted successfully.");

        }
    }
 }


