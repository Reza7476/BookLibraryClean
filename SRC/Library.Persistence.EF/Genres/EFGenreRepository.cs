using Library.Entities;
using Library.Services.Genres.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EF.Genres;
public class EFGenreRepository : GenreRepository
{

    private readonly EFDataContext _context;

    public EFGenreRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Genre genre)
    {
        _context.Genres.Add(genre); 
    }

    public void Delete(Genre genre)
    {
        _context.Genres.Remove(genre); 
    }

    public void Edit(Genre genre)
    {
        _context.Genres.Update(genre);
    }

    public async Task<List<Genre>> GetAll()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre?> GetById(int id)
    {
       return await _context.Genres.Where(g=>g.Id== id).FirstOrDefaultAsync();  
    }

    public async Task<Genre?> GeyByTitle(string name)
    {
        return await _context.Genres.Where(g => g.Title == name).FirstOrDefaultAsync();
    }

    public async Task<bool> IsExist(int id)
    {
        return await _context.Genres.AnyAsync(g => g.Id == id);
    }

    public async Task<bool> IsExist(string title)
    {
      return await _context.Genres.AnyAsync(g=>g.Title== title);
    }
}
