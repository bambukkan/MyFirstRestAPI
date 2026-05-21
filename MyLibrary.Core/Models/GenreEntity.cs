
namespace MyLibrary.Core.Models;

public class GenreEntity
{
    public Guid Id {get;set;}
    public string Name {get;set;} = string.Empty;
    public List<BookEntity> Books {get;set;} = new List<BookEntity>();
}