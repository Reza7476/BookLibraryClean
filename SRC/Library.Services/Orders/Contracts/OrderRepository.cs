using Library.Entities;
using System.Linq.Expressions;

namespace Library.Services.Orders.Contracts;
public interface OrderRepository
{

    void Add(Order order);

    void AddOrderItem(OrderItem item);
    void Edit(OrderItem item);
    void Delete(OrderItem item);

    Task<List<OrderItem>?> GetOrderItemByUserId(Expression<Func<OrderItem, bool>> where);

    Task<Order?> UserOrder(int usreId);
    Task<Order?> GetByUserId(Expression<Func<Order, bool>> where);
    Task<List<Order>?> GetAll();


}
