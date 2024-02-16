namespace Library.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int NumberOfBook { get;  set; }
    public DateTime ReturnDate { get;  set; }
    public DateTime OrderDate { get;  set; }
    public int BookId { get;  set; }
    public int OrderId { get; set; }
    public bool ReturnStatus { get;  set; }
    public Order Order { get; set; }
    public Book Book { get; set; }

}
