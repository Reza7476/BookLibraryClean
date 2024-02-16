using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Users.Contracts.Dtos;
public class UserDto
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }


    public List<BorrowedBooksDto>? BorrowedBooks { get; set; } 
    public List<CurrenrBorrowBooksDto>? CurrentBorrowBooks { get; set; } 
}
