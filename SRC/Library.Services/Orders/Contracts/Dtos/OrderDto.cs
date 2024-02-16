namespace Library.Services.Orders.Contracts.Dtos;
public class OrderDto
{
    public int Id { get; set; }
    public int NumberOfNotReturnedBook { get; set; }
    public string OrderDate { get; set; }
    public int UserId { get; set; }

    public List<OrderItemDto>? orderItems { get; set; }
}
