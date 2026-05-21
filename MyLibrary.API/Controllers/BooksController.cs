using Microsoft.AspNetCore.Mvc;
using MyLibrary.Core.Abstractions;

[ApiController]
[Route("books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _bookService.Get());
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