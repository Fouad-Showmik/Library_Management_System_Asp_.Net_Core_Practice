namespace LibraryManagementSystem.Models
{
    public class BookDto
    {  
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public required int TotalCopies { get; set; }
        public required int AvailableCopies { get; set; }
    }
}
