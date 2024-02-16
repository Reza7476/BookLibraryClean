using Library.Services.Books.Contracts.Dtos;

namespace Library.Services.Books.Contracts;
public interface BookServices
{

    Task Add(AddBookDto command);
    Task Edit(int id, EditBookDto command);
    Task Delete(int id);

    Task<BookDto> GetById(int id);
    Task<List<BookDto>> GetAll();
    Task<List<BookDto>> GetByFilter(FilterBookDto command);
}
