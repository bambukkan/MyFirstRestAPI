public record GenreRequest(
    string Name,
    List<Guid> BookIds
);