using Library.Services.Authers.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Authers.Contracts;
public interface AuthorService
{

    public Task Add(AddAuthorDto command);
    public Task Edit(int id, EditAuthorDto command);
    public Task Delete(int id);

    public Task<List<AuthorDto?>> GetAll();
    public Task<AuthorDto?> GetById(int id);

    public Task<AuthorDto>? GetByName(string name);

}
