using Microsoft.EntityFrameworkCore;
using MyLibrary.Core.Models;
using MyLibrary.Core.Abstractions;

namespace MyLibrary.DataAccess.Repositories;

public class GenresRepository : IGenresRepository
{
    private readonly LibraryDbContext _dbContext;

    public GenresRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GenreEntity>> Get()
    {
        return await _dbContext.Genres.AsNoTracking().ToListAsync();
    }
    public async Task<List<GenreEntity>> GetWithBooks()
    {
        return await _dbContext.Genres.AsNoTracking().Include(g => g.Books).ToListAsync(); // Вот тут надо будет рзаобраться
    }
    public async Task<List<GenreEntity>> GetByIds(List<Guid> ids)
    {
        return await _dbContext.Genres
            .Where(g => ids.Contains(g.Id)).ToListAsync();
    }
    public async Task Add(GenreEntity genreEntity)
    {
        await _dbContext.Genres.AddAsync(genreEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        await _dbContext.Genres
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task Update(Guid id, string name)
    {
        await _dbContext.Genres
            .Where(g => g.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(g => g.Name,name)
            );
    }
}
