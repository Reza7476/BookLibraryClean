using Library.Entities;

namespace Library.Services.Books.Contracts.Dtos;
public class BookDto
{



    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public int Count { get; set; }
    public int NumberOfBorrowBook { get; set; }
    public int AutherId { get; set; }
    public string AuthorName { get; set; }
    public int RestOfBook { get; set; }

    public int GenreId { get; set; }
    public string GenreTitle { get; set; }



}
