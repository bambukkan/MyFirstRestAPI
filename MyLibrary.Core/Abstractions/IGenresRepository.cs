using MyLibrary.Core.Models;
namespace MyLibrary.Core.Abstractions;

public interface IGenresRepository
{

    public Task<List<GenreEntity>> Get();
    public Task<List<GenreEntity>> GetWithBooks();
    public Task<List<GenreEntity>> GetByIds(List<Guid> ids);
    public Task Add(GenreEntity genreEntity); 
 
    public Task Delete(Guid id);

    public Task Update(Guid id, string name); 
}