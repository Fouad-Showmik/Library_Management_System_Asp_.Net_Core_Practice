namespace LibraryManagementSystem.Models.Entities
{
    //1 book --> 1 Author and 1 book ---> 1 Category
    public class Book
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public required int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category {  get; set; }
        public required int TotalCopies { get; set; }
        public required int AvailableCopies { get; set; }
    }
}
