
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Abstractions;

public interface IBooksRepository
{
    Task<List<BookEntity>> Get();   
    Task<List<BookEntity>> GetWithAuthors();   
    Task<List<BookEntity>> GetWithGenres();   
    Task Add(BookEntity book);
    Task Delete(Guid id);
    Task Update(Guid id,string title, decimal price);
}