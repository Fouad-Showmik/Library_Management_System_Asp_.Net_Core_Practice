namespace LibraryManagementSystem.Models.Entities
{   
    //1 catergory can have multiple books (1 category ---> many books)
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
