using Microsoft.EntityFrameworkCore;
using MyLibrary.Core.Abstractions;
using MyLibrary.Core.Models;

namespace MyLibrary.DataAccess.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly LibraryDbContext _dbContext;

    public BooksRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<BookEntity>> Get()
    {
        return await _dbContext.Books.AsNoTracking().ToListAsync();
    }

    public async Task<List<BookEntity>> GetWithAuthors()
    {
        return await _dbContext.Books.AsNoTracking().Include(b => b.Author).ToListAsync();
    }
    public async Task<List<BookEntity>> GetWithGenres()
    {
        return await _dbContext.Books.AsNoTracking().Include(b => b.Genres).ToListAsync();
    }
    public async Task Add(BookEntity bookEntity)
    {
        await _dbContext.Books.AddAsync(bookEntity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Delete(Guid id)
    {
        await _dbContext.Books.Where(a => a.Id == id).ExecuteDeleteAsync();
    }
    public async Task Update(Guid id,string title,decimal price)
    {
        await _dbContext.Books.Where(a => a.Id == id).ExecuteUpdateAsync( s => s
            .SetProperty(t => t.Title,title)
            .SetProperty(p => p.Price, price)
            );
    }
}