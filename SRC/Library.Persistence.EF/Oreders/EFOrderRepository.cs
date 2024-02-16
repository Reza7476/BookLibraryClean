using Library.Entities;
using Library.Services.Orders.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.Oreders;
public class EFOrderRepository : OrderRepository
{


    private readonly EFDataContext _context;

    public EFOrderRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {

        _context.Orders.Add(order);


    }

    public void AddOrderItem(OrderItem item)
    {
        _context.OrderItems.Add(item);
    }

    public void Delete(OrderItem item)
    {

        _context.OrderItems.Remove(item);
    }

    public void Edit(OrderItem item)
    {
        _context.OrderItems.Update(item);
    }

    public async Task<List<Order>?> GetAll()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(o=>o.Book)
            .ToListAsync();
    }

    public async Task<Order?> GetByUserId(Expression<Func<Order, bool>> where)
    {
        return await _context.Orders
            .Include(x=>x.User)
           .Include(o => o.OrderItems)
           .ThenInclude(x => x.Book)
           .FirstOrDefaultAsync();
    }

    public async Task<List<OrderItem>?> GetOrderItemByUserId(Expression<Func<OrderItem, bool>> where)
    {
        return await _context.OrderItems
            .Include(x => x.Book)
            
            .Where(where)
            .ToListAsync();
    }

    public async Task<Order?> UserOrder(int userId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(x=>x.Book)
            .FirstOrDefaultAsync(o => o.UserId == userId);
    }
}
