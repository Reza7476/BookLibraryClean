using Library.Entities;
using Library.Services.Books.Contracts;
using Library.Services.Orders.Contracts;
using Library.Services.Orders.Contracts.Dtos;
using Library.Services.Users.Contracts;
using System.Data;
using Tavv.Contract;

namespace Library.Services.Orders;
public class OrederAppService : OrderService
{

    private readonly OrderRepository _orderRepository;
    private readonly BookRepository _bookRepository;
    private readonly UserRepository _userRepository;
    private readonly UnitOfWork _unitOfWork;

    public OrederAppService(OrderRepository orderRepository,
        BookRepository bookRepository,
        UserRepository userRepository,
        UnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(AddOrderDto command)
    {
        var userExist = await _userRepository.IsExist(command.UserId);
        if (userExist == false)
            throw new Exception("user not found");
        var bookExist = await _bookRepository.IsExist(command.BookId);
        if (bookExist == false)
            throw new Exception("book not found");
        var book = await _bookRepository.GetById(command.BookId);
        var bookInventory = book.RestOfBook;
        if (command.NumberOfBook > bookInventory)
            throw new Exception("There is not enough book stock ");
        if (command.NumberOfBook > 4)
            throw new Exception("user can not rent morethen 4 books");
        var userOrder = await _orderRepository.UserOrder(command.UserId);
        if (userOrder == null)
        {
            Order newOrder = new Order()
            {
                UserId = command.UserId,
                NumberOfNotReturnedBook = command.NumberOfBook,
                OrderDate = DateTime.Now,
                OrderItems = new()
            };
            newOrder.OrderItems.Add(new OrderItem()
            {
                NumberOfBook = command.NumberOfBook,
                ReturnDate = command.ReturnDate,
                OrderDate = DateTime.Now,
                ReturnStatus = false,
                BookId = command.BookId,
            });
            await _unitOfWork.Begin();
            try
            {
                _orderRepository.Add(newOrder);
                await _unitOfWork.Complete();
                book.NumberOfBorrowBook = book.NumberOfBorrowBook + command.NumberOfBook;
                book.RestOfBook = book.RestOfBook - command.NumberOfBook;
                await _unitOfWork.Complete();
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RolleBack();
                throw new Exception(ex.Message);
            }
        }
        else
        {
            if (userOrder.NumberOfNotReturnedBook >= 4)
                throw new Exception("user not allow to rent book");
            if ((userOrder.NumberOfNotReturnedBook + command.NumberOfBook) > 4)
                throw new Exception("user not allow to rent book more than 4 books");
            OrderItem newItem = new OrderItem()
            {
                NumberOfBook = command.NumberOfBook,
                ReturnDate = command.ReturnDate,
                OrderDate = DateTime.Now,
                ReturnStatus = false,
                BookId = command.BookId,
                OrderId = userOrder.Id
            };
            await _unitOfWork.Begin();
            try
            {
                _orderRepository.AddOrderItem(newItem);
                await _unitOfWork.Complete();
                userOrder.NumberOfNotReturnedBook = userOrder.NumberOfNotReturnedBook + command.NumberOfBook;
                await _unitOfWork.Complete();
                book.NumberOfBorrowBook = book.NumberOfBorrowBook + command.NumberOfBook;
                book.RestOfBook = book.RestOfBook - command.NumberOfBook;
                await _unitOfWork.Complete();
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RolleBack();
                throw new Exception(ex.Message);
            }
        }
    }
    public async Task<List<OrderDto>?> GetAll()
    {
        var orders = await _orderRepository.GetAll();
        List<OrderDto> orderDtos = new();
        foreach (var orderDto in orders)
        {
            List<OrderItemDto>  items = new List<OrderItemDto>();   
            foreach (var item in orderDto.OrderItems)
            {
                OrderItemDto itemDto = new OrderItemDto()
                {
                    Id=item.Id,
                    NumberOfBook=item.NumberOfBook,
                    ReturnDate=item.ReturnDate.ToShortDateString(),
                    OrderDate=item.OrderDate.ToShortDateString(),
                    ReturnStatus=item.ReturnStatus,
                    BookId=item.BookId,
                    BookName=item.Book.Title,
                    OrderId =item.OrderId,
                };
                items.Add(itemDto);
            }
            OrderDto order = new OrderDto()
            {
                Id = orderDto.Id,
                NumberOfNotReturnedBook = orderDto.NumberOfNotReturnedBook,
                OrderDate = orderDto.OrderDate.ToShortDateString(),
                orderItems = items,
                UserId=orderDto.UserId
            };
            orderDtos.Add(order);
        }
        return orderDtos;
    }
    public async Task ReturnBook(ReturnBookDto command)
    {
        var userOrder = await _orderRepository.UserOrder(command.UserId);
        if (userOrder == null)
            throw new Exception("User dont have any order");
        var orderItem = userOrder.OrderItems.FirstOrDefault(x => x.Id == command.OrderItemId && x.ReturnStatus == false);
        if (orderItem == null)
            throw new Exception("orderItem not found");
        var book = await _bookRepository.GetById(command.BookId);
        await _unitOfWork.Begin();
        try
        {
            orderItem.ReturnStatus = true;
            await _unitOfWork.Complete();
            userOrder.NumberOfNotReturnedBook = userOrder.NumberOfNotReturnedBook - orderItem.NumberOfBook;
            await _unitOfWork.Complete();
            book.NumberOfBorrowBook = book.NumberOfBorrowBook - orderItem.NumberOfBook;
            book.RestOfBook = book.RestOfBook + orderItem.NumberOfBook;
            await _unitOfWork.Complete();
            await _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RolleBack();
            throw new Exception(ex.Message);
        }




    }
}
