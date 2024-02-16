namespace Library.Services.Orders.Contracts.Dtos;
public class OrderItemDto
{

    public int Id { get; set; }
    public int NumberOfBook { get; set; }
    public string ReturnDate { get; set; }
    public string OrderDate { get; set; }
    public bool ReturnStatus { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; }
    public int OrderId { get; set; }

}

