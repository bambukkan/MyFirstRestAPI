using Microsoft.EntityFrameworkCore;
using MyLibrary.Core.Configurations;
using MyLibrary.Core.Models;
namespace MyLibrary.DataAccess;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books {get; set;}

    public DbSet<GenreEntity> Genres {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}