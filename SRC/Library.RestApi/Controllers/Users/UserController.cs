using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers.Users;
[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public async Task Add(AddUserDto command)
    {
        await _userService.Add(command);
    }

    [HttpPatch("{id}")]
    public async Task Edit([FromRoute] int id, EditUserDto command)
    {
        await _userService.Edit(id, command);
    }


    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _userService.Delete(id);
    }
    [HttpGet]
    public async Task<List<UserDto?>> GetAll()
    {
        return await _userService.GetAll();

    }

    [HttpGet("{userId}")]
    public async Task<BorrowBookByUserDto?> BorrowBookByUser([FromRoute]int userId)
    {
        return await _userService.GetOrderByUserId(userId);
    }
}
