
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Abstractions;

public interface IBooksRepository
{
    Task<List<BookEntity>> Get(int page,int pageSize
    ,string? title, decimal? minPrice, decimal? maxPrice, string? genre);   
    Task<List<BookEntity>> GetWithAuthors();   
    Task<List<BookEntity>> GetWithGenres();   
    Task Add(BookEntity book);
    Task Delete(Guid id);
    Task Update(Guid id,string title, decimal price);
}