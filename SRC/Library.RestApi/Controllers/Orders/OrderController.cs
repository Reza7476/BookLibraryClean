using Library.Services.Orders.Contracts;
using Library.Services.Orders.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers.Orders;
[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{


    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost]
    public async Task Add(AddOrderDto command)
    {
        await _orderService.Add(command);
    }
    [HttpPatch("return-book")]
    public async Task ReturnBook([FromQuery]ReturnBookDto command)
    {
        await _orderService.ReturnBook(command);
    }
    [HttpGet]
    public async Task<List<OrderDto>?> GetAll()
    {
        return await _orderService.GetAll();
    }
}
