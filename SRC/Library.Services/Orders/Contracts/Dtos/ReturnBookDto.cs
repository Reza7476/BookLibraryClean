using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Orders.Contracts.Dtos;
public class ReturnBookDto
{
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public int OrderItemId { get; set; }
    public int BookId { get; set; }
}
