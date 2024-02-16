using Library.Services.Orders.Contracts.Dtos;

namespace Library.Services.Orders.Contracts;
public interface OrderService
{
    Task Add(AddOrderDto command);
    Task ReturnBook(ReturnBookDto command);
    Task<List<OrderDto>?> GetAll();

}
