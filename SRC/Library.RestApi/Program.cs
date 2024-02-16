using Library.Persistence.EF;
using Library.Persistence.EF.Authors;
using Library.Persistence.EF.Books;
using Library.Persistence.EF.Genres;
using Library.Persistence.EF.Oreders;
using Library.Persistence.EF.Users;
using Library.Services.Authers;
using Library.Services.Authers.Contracts;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using Library.Services.Genres;
using Library.Services.Genres.Contracts;
using Library.Services.Orders;
using Library.Services.Orders.Contracts;
using Library.Services.Users;
using Library.Services.Users.Contracts;
using Microsoft.Data.SqlClient;
using Tavv.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFDataContext>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

builder.Services.AddScoped<AuthorService, AuthorAppService>();
builder.Services.AddScoped<AuthorRepository, EFAutherRepository>();

builder.Services.AddScoped<GenreRepository, EFGenreRepository>();
builder.Services.AddScoped<GenreServices, GenerAppServices>();

builder.Services.AddScoped<BookRepository, EFBookRepository>();
builder.Services.AddScoped<BookServices, BookAppServices>();

builder.Services.AddScoped<UserService, UserAppService>();
builder.Services.AddScoped<UserRepository, EFUserRepository>();

builder.Services.AddScoped<OrderService, OrederAppService>();
builder.Services.AddScoped<OrderRepository, EFOrderRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
