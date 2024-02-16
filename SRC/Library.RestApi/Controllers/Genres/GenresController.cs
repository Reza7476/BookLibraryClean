using Library.Services.Genres.Contracts;
using Library.Services.Genres.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Library.RestApi.Controllers.Genres;
[Route("api/genres")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly GenreServices _genreService;

    public GenresController(GenreServices genreService)
    {
        _genreService = genreService;
    }
    [HttpPost]
    public async Task Add(AddGenreDto command)
    {
        await _genreService.Add(command);
    }
    [HttpPatch("{id}")]
    public async Task Edit([FromRoute] int id, EditGenreDto command)
    {
        await _genreService.Edit(id, command);
    }
    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] int id)
    {
        await _genreService.Delete(id);
    }
   
    [HttpGet("{id}")]
    public async Task<GenreDto> GetById([FromRoute] int id)
    {
        return await _genreService.GetById(id);
    }
    [HttpGet]
    public async Task<List<GenreDto>> GetAll()
    {
        return await _genreService.GetAll();
    }

  
}
