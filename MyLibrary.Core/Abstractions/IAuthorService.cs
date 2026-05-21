using MyLibrary.Core.Models;

namespace MyLibrary.Core.Abstractions;

public interface IAuthorService
{
    public Task<List<AuthorEntity>> Get();
    public Task<Guid> CreateAuthorAsync(AuthorRequest request);
    public Task DeleteAuthorAsync(Guid id);
    public Task UpdateAuthorAsync(AuthorRequest request,Guid id);
}