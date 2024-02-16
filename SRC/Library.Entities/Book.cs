namespace Library.Entities;

public class Book
{
   

    public int Id { get; set; }
    public string Title { get;  set; }
    public string Category { get; set; }
    public int Count { get; set; }
    public int NumberOfBorrowBook { get; set; }
    public int AutherId { get; set; }

    public int RestOfBook { get; set; }
    public Author Auther { get; set; }

    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    public List<OrderItem> OrderItems { get; set; }


}
