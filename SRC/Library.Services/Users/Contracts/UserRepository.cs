using Library.Entities;
using System.Linq.Expressions;

namespace Library.Services.Users.Contracts;
public interface UserRepository
{
    void Add(User user);
    void Edit(User usre);
    void Delete(User user);


    Task<List<User?>> GetAll();
    Task<List<User>> GetByFilter(Expression<Func<User, bool>> where);
    Task<bool> IsExist(int id);
    Task<bool> PhoneExist(string phone);
    Task<User?> GetById(int id);



}
