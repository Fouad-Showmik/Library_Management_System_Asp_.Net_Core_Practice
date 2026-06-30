using LibraryManagementSystem.Data;
using LibraryManagementSystem.Managers.Interfaces;
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
        private readonly IMemberManager _memberManager;

        public MemberController(IMemberManager memberManager)
        {
            _memberManager = memberManager;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var member = await _memberManager.GetAllMember();
            return Ok(member);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberManager.GetMemberById(id);
            if (member is null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberDto dto)
        {
            var member = await _memberManager.CreateMember(dto);
            return Ok(member);
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update(int id, MemberDto dto)
        {
            var member = await _memberManager.UpdateMember(id, dto);
            if (member is null) return NotFound();
            return Ok(member);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberManager.DeleteMember(id);
            if (member is null) return NotFound();
            return Ok(member);
        }
}
}


