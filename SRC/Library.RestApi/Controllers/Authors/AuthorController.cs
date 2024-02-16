using Library.Services.Authers.Contracts;
using Library.Services.Authers.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers.Authors;
[Route("api/author")]
[ApiController]
public class AuthorController : ControllerBase
{

    private readonly AuthorService _authorService;

    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task Add(AddAuthorDto command)
    {
        await _authorService.Add(command);
    }
    [HttpPatch("{id}")]
    public async Task Edit([FromRoute] int id, EditAuthorDto command)
    {
        await _authorService.Edit(id, command);

    }

    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await _authorService.Delete(id);
    }
    [HttpGet("{id}")]
    public async Task<AuthorDto?> GetById([FromRoute]int id)
    {
       return await _authorService.GetById(id);
    }
    [HttpGet]
    public async Task<List<AuthorDto?>> GetAll()
    {
        return await  _authorService.GetAll();
    }
}
