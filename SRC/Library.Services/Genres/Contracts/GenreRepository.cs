using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Genres.Contracts;
public interface GenreRepository
{

    void Add(Genre genre);
    void Edit(Genre genre);
    void Delete(Genre genre);

    Task<bool> IsExist(int id);
    Task<bool> IsExist(string title);
    Task<Genre?> GetById(int id);
    Task<List<Genre>> GetAll();
    Task<Genre?> GeyByTitle(string name);
}
