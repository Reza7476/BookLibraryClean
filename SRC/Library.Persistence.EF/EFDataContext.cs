using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.EF;
public class EFDataContext : DbContext
{
    public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
    {

    }
    public DbSet<Author> Authers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem>OrderItems { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
               .UseSqlServer("Server=DESKTOP-9PR0IFL;Database=BookLibraryClean;Trusted_Connection=true;TrustServerCertificate=true");
    }

}
