using Library.Entities;

namespace Library.Services.Authers.Contracts;
public interface AuthorRepository
{

    void Add(Author auther);
    void Update(Author auther);
    void Delete(Author auther);

    Task <bool> IsExist(int  id);
    Task<List<Author>?> GetAll();
    Task<Author?> GetById(int id);
    Task<Author?> GetByName(string name);
}
