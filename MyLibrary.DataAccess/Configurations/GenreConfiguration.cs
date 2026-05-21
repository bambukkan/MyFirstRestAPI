
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Core.Models;

namespace MyLibrary.Core.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder.HasKey(g => g.Id);

        builder.HasMany(g => g.Books)
            .WithMany(b => b.Genres);
    }
}