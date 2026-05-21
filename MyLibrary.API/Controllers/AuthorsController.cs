

using Microsoft.AspNetCore.Mvc;
using MyLibrary.Core.Abstractions;
using MyLibrary.DataAccess.Repositories;

[ApiController]
[Route("authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.Get());
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAuthorAsync(id);
        return Ok(id);
    }
    [HttpPost]
    public async Task<IActionResult> Create(AuthorRequest request)
    {
        return Ok(await _service.CreateAuthorAsync(request));
    }
    [HttpPut]
    public async Task<IActionResult> Update(AuthorRequest request,Guid id)
    {
        await _service.UpdateAuthorAsync(request,id);
        return Ok(id);
    }
}