
namespace MyLibrary.Core.Models;

public class AuthorEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname{ get; set; }

    public List<BookEntity> Books { get; set; } = new List<BookEntity>();
}
