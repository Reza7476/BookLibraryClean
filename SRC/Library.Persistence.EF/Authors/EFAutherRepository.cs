using Library.Entities;
using Library.Services.Authers.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.EF.Authors;
public class EFAutherRepository : AuthorRepository
{
    private readonly EFDataContext _context;

    public EFAutherRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Author auther)
    {

        _context.Authers.Add(auther);
    }

    public void Update(Author auther)
    {
        _context.Update(auther);
    }

    public void Delete(Author auther)
    {
        _context.Remove(auther);
    }



    public async Task<List<Author>?> GetAll()
    {
        return await _context.Authers.ToListAsync();
    }


    public async Task<Author?> GetById(int id)
    {
        return await _context.Authers.Where(a => a.Id == id).FirstOrDefaultAsync();
    }


    public async Task<Author?> GetByName(string name)
    {
        return await _context.Authers.FirstOrDefaultAsync(_ => _.Name == name);
    }

    public async Task<bool> IsExist(int id)
    {
        return await _context.Authers.AnyAsync(a => a.Id == id);
    }
}
