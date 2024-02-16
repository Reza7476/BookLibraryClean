using Library.Services.Genres.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Genres.Contracts;
public  interface GenreServices
{


    Task Add(AddGenreDto command);
    Task Edit(int id,EditGenreDto command);    
    Task Delete(int id);

    Task<List<GenreDto>> GetAll();
    Task <GenreDto> GetById(int id);
    Task<GenreDto > GetByName(string name); 
}
