
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Abstractions;

public interface IBookService
{
    public Task<List<BookEntity>> Get();
    public Task<List<BookEntity>> GetWithAuthors();
    public Task<List<BookEntity>> GetWithGenres();
    public Task<Guid> CreateBookAsync(BookRequest book);
}