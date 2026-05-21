using MyLibrary.Core.Abstractions;
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorsRepository _authorsRepository;
    public AuthorService(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task<List<AuthorEntity>> Get()
    {
        return await _authorsRepository.Get();
    }
    public async Task<Guid> CreateAuthorAsync(AuthorRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Имя не найдено",nameof(request.Name));
        }
        if (string.IsNullOrWhiteSpace(request.Surname))
        {
            throw new ArgumentException("Фамилия не найдена",nameof(request.Surname));

        }
        var authorEntity = new AuthorEntity
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Surname = request.Surname
        };
        await _authorsRepository.Add(authorEntity);
        return authorEntity.Id;
    }
    public async Task DeleteAuthorAsync(Guid id)
    {
        await _authorsRepository.Delete(id);
    }
    public async Task UpdateAuthorAsync(AuthorRequest request,Guid id)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Имя не найдено",nameof(request.Name));
        }
        if (string.IsNullOrWhiteSpace(request.Surname))
        {
            throw new ArgumentException("Фамилия не найдена",nameof(request.Surname));
            
        }
        await _authorsRepository.Update(request,id);
    }
}