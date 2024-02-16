using System.ComponentModel.DataAnnotations;

namespace Library.Services.Authers.Contracts.Dtos;

public class AddAuthorDto
{
    [Required]
    [MaxLength(75)]
    public string Name { get; set; }
}
