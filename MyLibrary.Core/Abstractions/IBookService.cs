
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Abstractions;

public interface IBookService
{
    public Task<List<BookEntity>> Get(BookFilter filter);
    public Task<List<BookEntity>> GetWithAuthors();
    public Task<List<BookEntity>> GetWithGenres();
    public Task<Guid> CreateBookAsync(BookRequest book);
}