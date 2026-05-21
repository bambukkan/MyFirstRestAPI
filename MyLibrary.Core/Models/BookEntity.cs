
namespace MyLibrary.Core.Models;

public class BookEntity
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public Guid AuthorId { get; set; }
    public AuthorEntity? Author { get; set; }
    public List<GenreEntity> Genres {get;set;} = new List<GenreEntity>();
}