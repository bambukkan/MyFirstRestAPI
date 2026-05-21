using MyLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Core.Abstractions;
namespace MyLibrary.DataAccess.Repositories;
public class AuthorsRepository : IAuthorsRepository{

    private readonly LibraryDbContext _dbContext;
    public AuthorsRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<AuthorEntity>> Get()
    {
        return await _dbContext.Authors
            .AsNoTracking()
            .ToListAsync();    
    }
    public async Task<List<AuthorEntity>> GetWithBooks()
    {
        return await _dbContext.Authors
            .AsNoTracking()
            .Include(a => a.Books)
            .ToListAsync();
    }

    public async Task<AuthorEntity?> GetById(Guid id)
    {
        return await _dbContext.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<AuthorEntity>> GetByFilter(string name)
    {
        var query = _dbContext.Authors.AsNoTracking();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(a => a.Name == name);
        }

        return await query.ToListAsync();
    }

    public async Task<List<AuthorEntity>> GetByPage(int page, int pageSize)
    {
        return await _dbContext.Authors
            .AsNoTracking()
            .Skip((page-1)* pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task Add(AuthorEntity authorEntity)
    {
        await _dbContext.AddAsync(authorEntity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Update(AuthorRequest request, Guid id)
    {
        await _dbContext.Authors
            .Where(a => a.Id == id)
            .ExecuteUpdateAsync(
                a => a
                .SetProperty(n => n.Name,request.Name)
                .SetProperty(s => s.Surname,request.Surname)
            );
    }

    public async Task Delete(Guid id)
    {
        await _dbContext.Authors
            .Where(a => a.Id == id)
            .ExecuteDeleteAsync();
    }
}
