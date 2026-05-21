using MyLibrary.Core.Models;
namespace MyLibrary.Core.Abstractions;

public interface IAuthorsRepository
{
    public Task<List<AuthorEntity>> Get();
    public Task<List<AuthorEntity>> GetWithBooks();
    public Task<AuthorEntity?> GetById(Guid id);
    public Task<List<AuthorEntity>> GetByFilter(string name);
    public Task<List<AuthorEntity>> GetByPage(int page, int pageSize);
    public Task Add(AuthorEntity authorEntity);
    public Task Update(AuthorRequest request, Guid id);
    public Task Delete(Guid id);


}