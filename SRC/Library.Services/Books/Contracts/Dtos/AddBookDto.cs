using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts.Dtos;
public class AddBookDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public int Count { get; set; }
    [Required]
    public int AutherId { get; set; }
    [Required]
    public int GenreId { get; set; }
}
