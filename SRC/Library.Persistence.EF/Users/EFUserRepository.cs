using Library.Entities;
using Library.Services.Users.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Persistence.EF.Users;
public class EFUserRepository : UserRepository
{
    private readonly EFDataContext _context;

    public EFUserRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public void Edit(User usre)
    {
        _context.Users.Update(usre);
    }

    public async Task<List<User?>> GetAll()
    {
       return await _context.Users
            .Include(u=>u.Orders)
            
            .ToListAsync();
    }

    public async Task<List<User>> GetByFilter(Expression<Func<User, bool>> where)
    {
        return await _context.Users
            .Include(u=>u.Orders)
            .ThenInclude(o=>o.OrderItems)
            .Where(where)
            .ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users
            .Include(u => u.Orders)
            .ThenInclude(o=>o.OrderItems)
            .FirstOrDefaultAsync(u=>u.Id==id);
    }

    public async Task<bool> IsExist(int id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);
    }

    public async Task<bool> PhoneExist(string phone)
    {
        return await _context.Users.AnyAsync(p => p.Phone == phone);
    }
}
