
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Core.Abstractions;
using MyLibrary.Core.Models;

[ApiController]
[Route("genres")]
public class GenresConroller : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresConroller(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _genreService.Get());
    }

    [HttpGet("with-books")]
    public async Task<IActionResult> GetWithBooks()
    {
        return Ok(await _genreService.GetWithBooks());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GenreRequest request)
    {
        var genreId = await _genreService.Add(request);
        return Ok(genreId);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _genreService.Delete(id);
        return Ok(id);
    }
    /*проблема: Ты забыл указать {id} в атрибутах маршрута. Сейчас Swagger не поймет, откуда брать этот Guid id. 
    Он решит, что ID нужно передавать где-то в теле запроса (Body) или в параметрах строки (Query), 
    а по правилам REST API идентификатор для удаления и обновления должен быть прямо в ссылке: DELETE /genres/твой-guid.*/
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, GenreRequest request)
    {
        await _genreService.Update(id, request);
        return Ok(id);
    }
}