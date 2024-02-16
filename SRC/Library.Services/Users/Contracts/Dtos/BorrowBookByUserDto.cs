using System.Security.Principal;

namespace Library.Services.Users.Contracts.Dtos;

public class BorrowBookByUserDto
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string  Name { get; set; }
    public string  phone { get; set; }
    public string  Email { get; set; }
    public List<BorrowedBooksDto>? BorrowedBooks { get; set; }
    public List<CurrenrBorrowBooksDto>? CurrenrBorrowBooks { get; set; }
}