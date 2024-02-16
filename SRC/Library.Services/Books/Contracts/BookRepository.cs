using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts;
public interface BookRepository
{

    void Add(Book book);
    void Update(Book book);
    void Delete(Book book);

    Task<bool> IsExist(int id);
    Task<int> BookInventory(int id);
    Task<List<Book>> GetAll();

    //public void Delete(Expression<Func<TEntity, bool>> where)
    Task<List<Book>> GetByFilter(Expression<Func<Book,bool>> where);
    Task<Book?> GetById(int id);
    //Task<List<Book>> GetByFilter();

}
