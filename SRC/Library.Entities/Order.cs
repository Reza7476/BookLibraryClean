namespace Library.Entities;

public class Order
{
    public int Id { get; set; }
    public int NumberOfNotReturnedBook { get;  set; }
    public DateTime OrderDate { get;  set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<OrderItem> OrderItems { get; set; }


}
