using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts.Dtos;
public class FilterBookDto
{
    public string?  Name { get; set; }
    public string?  Genre { get; set; }
    public string? Author { get; set; }
}
