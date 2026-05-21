public record BookRequest(
    string Title, 
    decimal Price, 
    Guid AuthorId,
    List<Guid> GenreIds
);