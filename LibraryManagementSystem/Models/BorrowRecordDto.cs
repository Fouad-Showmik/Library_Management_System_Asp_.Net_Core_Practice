using LibraryManagementSystem.Models.Entities;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecordDto
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public required DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
