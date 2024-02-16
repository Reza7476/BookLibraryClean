using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Users.Contracts.Dtos;
public  class BorrowedBooksDto
{
    public int Count { get; set; }
    public string  Title { get; set; }
}
