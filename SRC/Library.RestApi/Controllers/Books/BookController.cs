using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.RestApi.Controllers.Books;
[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{

    private readonly BookServices _bookServices;

    public BookController(BookServices bookServices)
    {
        _bookServices = bookServices;
    }

    [HttpPost]
    public async Task Add(AddBookDto command)
    {
        await _bookServices.Add(command);
    }

    [HttpPatch("{id}")]
    public async Task Edit([FromRoute]int id,EditBookDto command)
    {
        await _bookServices.Edit(id, command);  
    }
    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {

        await _bookServices.Delete(id);
    }

    [HttpGet("{id}")]
    public async Task<BookDto> GetById([FromRoute] int id)
    {
        return await _bookServices.GetById(id);
    }
    [HttpGet]
    public async Task<List<BookDto>> GetByFilter([FromQuery]FilterBookDto command)
    {
        return await _bookServices.GetByFilter(command);
    }

}
