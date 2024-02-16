using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Orders.Contracts.Dtos;
public class AddOrderDto
{

    public int UserId { get; set; }
    public int BookId { get; set; }
    public int  NumberOfBook { get; set; }
    public DateTime ReturnDate { get; set; }

}
