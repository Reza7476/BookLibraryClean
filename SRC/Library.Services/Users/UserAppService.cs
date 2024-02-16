using Library.Entities;
using Library.Services.Orders.Contracts;
using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;
using Tavv.Contract;

namespace Library.Services.Users;
public class UserAppService : UserService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly UserRepository _userRepository;

    private readonly OrderRepository _orderRepository;

    public UserAppService(UnitOfWork unitOfWork, UserRepository userRepository, OrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _orderRepository = orderRepository;
    }

    public async Task Add(AddUserDto command)
    {

        var phoneExist = await _userRepository.PhoneExist(command.Phone);
        if (phoneExist != false)
            throw new Exception("this phone number has already been registred");
        var user = new User()
        {
            Phone = command.Phone,
            Email = command.Email,
            Name = command.Name,
        };
        _userRepository.Add(user);
        await _unitOfWork.Complete();

    }

    public async Task Delete(int id)
    {
        var user = await _userRepository.GetById(id);
        if (user == null)
            throw new Exception("user not found");
        _userRepository.Delete(user);
        await _unitOfWork.Complete();


    }

    public async Task Edit(int id, EditUserDto command)
    {
        var user = await _userRepository.GetById(id);
        if (user == null)
            throw new Exception("user not found");
        user.Email = command.Email;
        user.Name = command.Name;
        user.Phone = command.Phone;
        _userRepository.Edit(user);
        await _unitOfWork.Complete();

    }

    public async Task<List<UserDto?>> GetAll()
    {
        var users = await _userRepository.GetAll();
        List<UserDto?> userDtos = new List<UserDto?>();
        foreach (var user in users)
        {
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Phone = user.Phone,
                Name = user.Name
            };
            userDtos.Add(userDto);
        }
        return userDtos;
    }

    public async Task<BorrowBookByUserDto?> GetOrderByUserId(int userId)
    {


        var order = await _orderRepository.GetByUserId(x => x.UserId == userId);

        if (order == null)
            throw new Exception("usre dont have any order");
        var userOrder = await _orderRepository.GetOrderItemByUserId(x => x.OrderId == order.Id);
        List<BorrowedBooksDto>? borrowedDtos = new();
        foreach (var borrowed in userOrder.Where(x => x.ReturnStatus == true))
        {
            BorrowedBooksDto borrowDto = new BorrowedBooksDto()
            {
                Count = borrowed.NumberOfBook,
                Title = borrowed.Book.Title
            };
            borrowedDtos.Add(borrowDto);
        }
        List<CurrenrBorrowBooksDto>? currenrBorrowDtos = new();

        foreach (var borrow in userOrder.Where(x => x.ReturnStatus == false))
        {
            CurrenrBorrowBooksDto currentBorrowDto = new CurrenrBorrowBooksDto()
            {
                Count = borrow.NumberOfBook,
                Title = borrow.Book.Title
            };
            currenrBorrowDtos.Add(currentBorrowDto);
        }

        BorrowBookByUserDto borrowBookByUser = new BorrowBookByUserDto()
        {
            OrderId = order.Id,
            UserId = userId,
            Email = order.User.Email,
            Name = order.User.Name,
            phone = order.User.Phone,
            BorrowedBooks = borrowedDtos,
            CurrenrBorrowBooks = currenrBorrowDtos,
        };

        return borrowBookByUser;


    }
}
