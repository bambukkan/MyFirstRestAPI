using Microsoft.AspNetCore.Mvc;
using MyLibrary.API.Filters;
using MyLibrary.Core.Abstractions;

[ApiController]
[TypeFilter<FilterValidation>()]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BookFilter filter)
    {
        return Ok(await _bookService.Get(filter));
    }

    [HttpGet("with-authors")]
    public async Task<IActionResult> GetWithAuthors()
    {
        return Ok(await _bookService.GetWithAuthors());
    }


    [HttpGet("with-genres")]
    public async Task<IActionResult> GetWithGenres()
    {
        return Ok(await _bookService.GetWithGenres());
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] BookRequest request)
    {
        var book = await _bookService.CreateBookAsync(request);
        return Ok(book);
    }
}