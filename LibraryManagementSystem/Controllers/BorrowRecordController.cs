//using LibraryManagementSystem.Data;
//using LibraryManagementSystem.Managers.Interfaces;
//using LibraryManagementSystem.Models;
//using LibraryManagementSystem.Models.Entities;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace LibraryManagementSystem.Controllers
//{
//    [Route("api/borrowRecord")]
//    [ApiController]
//    public class BorrowRecordController : ControllerBase
//    {
//        private readonly IBorrowRecordManager _borrowRecordManager;

//        public BorrowRecordController(IBorrowRecordManager borrowRecordManager)
//        {
//            _borrowRecordManager = borrowRecordManager;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            var res = await _borrowRecordManager.GetAllAsync();
//            return Ok(res);
//        }

//        [HttpGet]
//        [Route("{id:int}")]

//        public async Task<IActionResult> GetByID(int id)
//        {
//            var res = await _borrowRecordManager.GetByIdAsync(id);
//            if (res is null) return NotFound();
//            return Ok(res);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(BorrowRecordDto dto)
//        {
//            var res = await _borrowRecordManager.CreateAsync(dto);
//            return Ok(res);
//        }

//        [HttpPut]
//        [Route("{id:int}")]

//        public async Task<IActionResult> Update(int id, BorrowRecordDto dto)
//        {
//            var res = await _borrowRecordManager.UpdateAsync(id, dto);
//            if (res is null) return NotFound();
//            return Ok(res);
//        }

//        [HttpDelete]
//        [Route("{id:int}")]

//        public async Task<IActionResult> Delete(int id)
//        {
//            var res = await _borrowRecordManager.DeleteAsync(id);
//            if(res is null) return NotFound();
//            return Ok(res);
//        }
//    }
//}
