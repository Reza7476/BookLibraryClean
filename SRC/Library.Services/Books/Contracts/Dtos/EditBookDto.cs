
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts.Dtos;
public class EditBookDto
{

    
    public string Title { get; set; }
    public string Category { get; set; }
    public int Count { get; set; }
    public int NumberOfBorrowBook { get; set; }
    public int RestOfBook { get; set; }


}
