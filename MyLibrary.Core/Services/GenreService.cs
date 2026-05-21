using MyLibrary.Core.Abstractions;
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Services;
public class GenreService : IGenreService
{
    private readonly IGenresRepository _genreRepository;

    public GenreService(IGenresRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<List<GenreEntity>> Get()
    {
        return await _genreRepository.Get();
    }
    public async Task<List<GenreEntity>> GetWithBooks()
    {
        return await _genreRepository.GetWithBooks();
    }
    

    public async Task<Guid> Add(GenreRequest request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            throw new ArgumentException("Имя не найдено",nameof(request.Name));
        }
        GenreEntity genre = new GenreEntity()
        {
            Id = Guid.NewGuid(),
            Name = request.Name  
        };

        await _genreRepository.Add(genre);
        return genre.Id;

    }
    public async Task Delete(Guid id)
    {
        await _genreRepository.Delete(id);
    }
    public async Task Update(Guid id,GenreRequest request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            throw new ArgumentException("Имя не найдено",nameof(request.Name));
        }
        await _genreRepository.Update(id,request.Name);
    }

}
