using Library.Services.Users.Contracts.Dtos;

namespace Library.Services.Users.Contracts;
public interface UserService
{

    Task Add(AddUserDto command);
    Task Edit(int id, EditUserDto command);
    Task Delete(int id);


    Task<BorrowBookByUserDto?> GetOrderByUserId(int userId);
    Task<List<UserDto?>> GetAll();
   
}
