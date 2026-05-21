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

    public async Task<List<BookEntity>> Get()
    {
        return await _bookRepository.Get();
    }

    public async Task<Guid> CreateBookAsync(BookRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Заголовок не найден",nameof(request.Title));
        }
        if(request.Price < 0){
            throw new ArgumentOutOfRangeException(nameof(request.Price),"Цена меньше нуля");
        }
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