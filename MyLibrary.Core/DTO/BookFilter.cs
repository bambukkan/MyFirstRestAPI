
using System.ComponentModel.DataAnnotations;

public record BookFilter(
    [Range(1, int.MaxValue, ErrorMessage = "Номер страницы не может быть меньше 1")]
    int page, 
    [Range(1, 10, ErrorMessage = "Размер страницы может быть только в диапазоне от 1 до 10")]
    int pageSize,
    [Required(ErrorMessage = "Заголовок не найден")]
    string? title,
    [Range(0, double.MaxValue, ErrorMessage = "Минимальная цена не может быть меньше 0")]
    decimal? minPrice,
    [Range(0, double.MaxValue, ErrorMessage = "Минимальная цена не может быть меньше 0")]
    decimal? maxPrice,
    [Required(ErrorMessage = "Жанр не найден")]
    string? genre
);