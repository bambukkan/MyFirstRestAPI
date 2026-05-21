using MyLibrary.Core.Models;
namespace MyLibrary.Core.Abstractions;
public interface IGenreService
{
    public Task<List<GenreEntity>> Get();
    public Task<List<GenreEntity>> GetWithBooks();

    public Task<Guid> Add(GenreRequest request);
    public Task Delete(Guid id);
    public Task Update(Guid id,GenreRequest request);
}