namespace LibraryManagementSystem.Models.Entities
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public Member? Member { get; set; }
        public int MemberId { get; set; }
        public Book? Book { get; set; }
        public int BookId { get; set; }
        public required DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } 
    }
}
