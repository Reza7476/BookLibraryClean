using Library.Entities;
using Library.Services.Authers.Contracts;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Library.Services.Genres.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavv.Contract;

namespace Library.Services.Books;
public class BookAppServices : BookServices
{


    private readonly UnitOfWork _unitOfWork;
    private readonly BookRepository _bookRepository;
    private readonly AuthorRepository _authorRepository;
    private readonly GenreRepository _genreRepository;

    public BookAppServices(UnitOfWork unitOfWork, BookRepository bookRepository, AuthorRepository authorRepository, GenreRepository genreRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _genreRepository = genreRepository;
    }

    public async Task Add(AddBookDto command)
    {
        var author = await _authorRepository.IsExist(command.AutherId);
        if (author == false)
            throw new Exception("author not found");

        var genre = await _genreRepository.IsExist(command.GenreId);
        if (genre == false)
            throw new Exception("genre not found");

        var newBook = new Book()
        {
            Title = command.Title,
            AutherId = command.AutherId,
            Category = command.Category,
            GenreId = command.GenreId,
            Count = command.Count,
            RestOfBook = command.Count,
            NumberOfBorrowBook = 0,
        };
        _bookRepository.Add(newBook);
        await _unitOfWork.Complete();
    }

    public async Task Delete(int id)
    {
        var book = await _bookRepository.GetById(id);
        if (book == null)
            throw new Exception("book not found");
        _bookRepository.Delete(book);
        await _unitOfWork.Complete();
    }

    public async Task Edit(int id, EditBookDto command)
    {
        var book = await _bookRepository.GetById(id);
        if (book == null)
            throw new Exception("book not found");
        book.Title = command.Title;
        book.Category = command.Category;
        book.RestOfBook = command.RestOfBook;
        book.NumberOfBorrowBook = command.NumberOfBorrowBook;
        book.Count = command.Count;
        _bookRepository.Update(book);
        await _unitOfWork.Complete();
    }

    public async Task<List<BookDto>> GetAll()
    {
        var books = await _bookRepository.GetAll();
        List<BookDto> bookDtos = new();
        foreach (var item in books)
        {
            BookDto bookDto = new BookDto()
            {
                AutherId = item.AutherId,
                AuthorName = item.Auther.Name,
                Category = item.Category,
                Count = item.Count,
                GenreId = item.GenreId,
                GenreTitle = item.Genre.Title,
                NumberOfBorrowBook = item.NumberOfBorrowBook,
                RestOfBook = item.RestOfBook,
                Title = item.Title,
                Id = item.Id
            };
            bookDtos.Add(bookDto);
        }
        return bookDtos;
    }

    public async Task<List<BookDto>> GetByFilter(FilterBookDto command)
    {

        var books = await _bookRepository.GetByFilter(b =>
        (b.Title == command.Name || command.Name == null)
        && (b.Genre.Title == command.Genre || command.Genre == null)
        && (b.Auther.Name == command.Author || command.Author == null));

        List<BookDto> bookDtos = new();

        if (books.Count > 0)
        {
            foreach (var item in books)
            {
                BookDto bookdto = new BookDto()
                {
                    AutherId = item.AutherId,
                    AuthorName = item.Auther.Name,
                    Category = item.Category,
                    Count = item.Count,
                    GenreId = item.GenreId,
                    GenreTitle = item.Genre.Title,
                    NumberOfBorrowBook = item.NumberOfBorrowBook,
                    RestOfBook = item.RestOfBook,
                    Title = item.Title,
                    Id = item.Id
                };

                bookDtos.Add(bookdto);
            }
        }
        return bookDtos;



    }

    public async Task<BookDto> GetById(int id)
    {
        var book = await _bookRepository.GetById(id);
        var bookDto = new BookDto()
        {
            AutherId = book.AutherId,
            AuthorName = book.Auther.Name,
            Category = book.Category,
            Count = book.Count,
            GenreId = book.GenreId,
            GenreTitle = book.Genre.Title,
            NumberOfBorrowBook = book.NumberOfBorrowBook,
            RestOfBook = book.RestOfBook,
            Title = book.Title,
            Id = book.Id
        };
        return bookDto;


    }
}
