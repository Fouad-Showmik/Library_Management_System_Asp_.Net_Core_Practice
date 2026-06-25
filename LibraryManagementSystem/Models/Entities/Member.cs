namespace LibraryManagementSystem.Models.Entities
{
    //1 member can borrow multiple books (1 member --> many books) 
    public class Member
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord> ();

    }
}
