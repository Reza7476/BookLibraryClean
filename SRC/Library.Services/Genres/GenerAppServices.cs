using Library.Entities;
using Library.Services.Genres.Contracts;
using Library.Services.Genres.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavv.Contract;

namespace Library.Services.Genres;
public class GenerAppServices : GenreServices
{



    private readonly UnitOfWork _unitOfWork;
    private readonly GenreRepository _genreRepository;

    public GenerAppServices(UnitOfWork unitOfWork, GenreRepository genreRepository)
    {
        _unitOfWork = unitOfWork;
        _genreRepository = genreRepository;
    }

    public async Task Add(AddGenreDto command)
    {
        var genre = await _genreRepository.IsExist(command.Title);
        if (genre == false)
        {
            var newGenre = new Genre()
            {
                Title = command.Title,
            };
            _genreRepository.Add(newGenre);
            await _unitOfWork.Complete();
        }
        else
        {
            throw new Exception("Genre is exist");
        }

    }

    public async Task Delete(int id)
    {
        var genre = await _genreRepository.GetById(id);
        if (genre != null)
        {
            _genreRepository.Delete(genre);
            await _unitOfWork.Complete();
        }
        else
        {
            throw new Exception("Genre not found");
        }

    }

    public async Task Edit(int id, EditGenreDto command)
    {
        var genre = await _genreRepository.GetById(id);
        if (genre != null)
        {
            genre.Title = command.Title;

            _genreRepository.Edit(genre);
            await _unitOfWork.Complete();
        }
        else
        {
            throw new Exception("Genre not found");
        }
    }

    public async Task<List<GenreDto>> GetAll()
    {

        var genres = await _genreRepository.GetAll();
        List<GenreDto> genre = new();
        if (genres != null)
        {

            foreach (var genreItem in genres)
            {
                GenreDto genreDto = new GenreDto()
                {
                    Id = genreItem.Id,
                    Title = genreItem.Title,
                };
                genre.Add(genreDto);
            }
        }
        return genre;


    }

    public async Task<GenreDto> GetById(int id)
    {
        var genre = await _genreRepository.GetById(id);
        if (genre == null)

            throw new Exception("genre not found");

        var model = new GenreDto()
        {
            Id = genre.Id,
            Title = genre.Title,
        };
        return model;


    }

    public async Task<GenreDto> GetByName(string name)
    {
        var genre = await _genreRepository.GeyByTitle(name);
        if (genre == null)
            throw new Exception("genre not found");
        var model = new GenreDto()
        {
            Id = genre.Id,
            Title = genre.Title,

        };
        return model;


    }
}
