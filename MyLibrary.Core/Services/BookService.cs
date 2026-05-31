using MyLibrary.Core.Abstractions;
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Services;
public class BookService : IBookService
{
    private readonly IBooksRepository _bookRepository;
    private readonly IAuthorsRepository _authorsRepository;
    private readonly IGenresRepository _genresRepository;
    
    public BookService(IBooksRepository bookRepository,
        IAuthorsRepository authorsRepository,
        IGenresRepository genresRepository)
    {
        _bookRepository = bookRepository;
        _authorsRepository = authorsRepository;
        _genresRepository = genresRepository;
    }
    public async Task<List<BookEntity>> GetWithAuthors()
    {
        return await _bookRepository.GetWithAuthors();
    }
    public async Task<List<BookEntity>> GetWithGenres()
    {
        return await _bookRepository.GetWithGenres();
    }

    public async Task<List<BookEntity>> Get(BookFilter filter)
    {

        if (filter.minPrice.HasValue && filter.maxPrice.HasValue && filter.minPrice.Value > filter.maxPrice.Value)
        throw new ArgumentException("Минимальная цена не может быть больше максимальной");
       
        return await _bookRepository.Get(page,
        pageSize,filter.title,filter.minPrice,filter.maxPrice,filter.genre);
    }

    public async Task<Guid> CreateBookAsync(BookRequest request)
    {
        var author = await _authorsRepository.GetById(request.AuthorId);
        if(author == null){
            throw new ArgumentOutOfRangeException(nameof(request.AuthorId),"Id автора не найден");
        }
        var genres = await _genresRepository.GetByIds(request.GenreIds); 

        BookEntity book = new BookEntity()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Price = request.Price,
            AuthorId = request.AuthorId,
            Genres = genres
        };
        await _bookRepository.Add(book);
        return book.Id;
    }
}