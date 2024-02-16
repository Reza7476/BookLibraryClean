using Library.Entities;
using Library.Services.Authers.Contracts;
using Library.Services.Authers.Contracts.Dtos;
using System.Xml.Schema;
using Tavv.Contract;

namespace Library.Services.Authers;
public class AuthorAppService : AuthorService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly AuthorRepository _authorRepository;
    public AuthorAppService(UnitOfWork unitOfWork, AuthorRepository authorRepository)
    {
        _unitOfWork = unitOfWork;
        _authorRepository = authorRepository;
    }

    public async Task Add(AddAuthorDto command)
    {
        var auther = new Author()
        {
            Name = command.Name,
        };
        _authorRepository.Add(auther);
        await _unitOfWork.Complete();
    }

    public async Task Delete(int id)
    {
        var auther = await _authorRepository.IsExist(id);
        if (auther == false)
            throw new Exception("auther not found");
        var authorDelete = await _authorRepository.GetById(id);
        _authorRepository.Delete(authorDelete!);
        await _unitOfWork.Complete();
    }

    public async Task Edit(int id, EditAuthorDto command)
    {
        var authorUpdate = await _authorRepository.GetById(id);
        if (authorUpdate != null)
        {
            authorUpdate.Name = command.Name;
            _authorRepository.Update(authorUpdate);
            await _unitOfWork.Complete();
        }
        throw new Exception("auther not found");
    }

    public async Task<List<AuthorDto?>> GetAll()
    {
        var model = new List<AuthorDto>();
        var result = await _authorRepository.GetAll();
        if (result != null)
        {
            foreach (var item in result)
            {
                AuthorDto auther = new AuthorDto()
                {
                    Name = item.Name,
                    Id = item.Id
                };
                model.Add(auther);
            }
        }
        return model;

    }

    public async Task<AuthorDto?> GetById(int id)
    {
        var auther = await _authorRepository.GetById(id);
        if (auther == null)
            throw new Exception("auther not found");
        var model = new AuthorDto()
        {
            Id = auther.Id,
            Name = auther.Name
        };
        return model;



    }

    public async Task<AuthorDto>? GetByName(string name)
    {

        var auther = await _authorRepository.GetByName(name);
        if (auther == null)
        {
            throw new Exception("auther not found");
        }
        var model = new AuthorDto()
        {
            Id = auther.Id,
            Name = auther.Name
        };

        return model;

    }
}
