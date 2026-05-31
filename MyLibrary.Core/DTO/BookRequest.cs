using System.ComponentModel.DataAnnotations;

public record BookRequest(
    [Required(ErrorMessage = "Заголовок не найден")]
    string Title, 
    [Range(0,double.MaxValue,ErrorMessage = "Цена меньше нуля")]
    decimal Price, 
    Guid AuthorId,
    List<Guid> GenreIds
);