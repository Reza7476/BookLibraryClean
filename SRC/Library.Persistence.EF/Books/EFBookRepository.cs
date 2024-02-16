using Library.Entities;
using Library.Services.Books.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.Books;
public class EFBookRepository : BookRepository
{



    private readonly EFDataContext _context;

    public EFBookRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
    }

    public  Task<int> BookInventory(int id)
    {
         throw new Exception();
    }

    public void Delete(Book book)
    {
        _context.Books.Remove(book);
    }

    public async Task<List<Book>> GetAll()
    {
        return await _context.Books
            .Include(b => b.Genre)
            .Include(b => b.Auther)
            .ToListAsync();
    }
    //  IEnumerable<TEntity> objects = dbSet.Where(where).AsEnumerable();
    ////  foreach (TEntity obj in objects)
    // {
    //  dbSet.Remove(obj);
    // }
    public async Task<List<Book>> GetByFilter(Expression<Func<Book, bool>> where)
    {

        return await _context.Books
            .Include(b=>b.Genre)
            .Include(b=>b.Auther)
            .Where(where)
            .ToListAsync();
    }

    public async Task<Book?> GetById(int id)
    {
        return await _context.Books
             .Where(b => b.Id == id)
             .Include(b => b.Genre)
             .Include(b => b.Auther)
             .FirstOrDefaultAsync();
    }

    public async Task<bool> IsExist(int id)
    {
        return await _context.Books.AnyAsync(b => b.Id == id);
    }

    public void Update(Book book)
    {
        _context.Books.Update(book);
    }
}
