namespace LibraryManagementSystem.Models.Entities
{
    //1 Author can have many books (1 --> many)
    public class Author
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Bio {  get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>(); 
    }
}
