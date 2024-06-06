using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(b => b.PageCount)
            .IsRequired();
        builder.Property(b => b.Summary)
            .HasMaxLength(1000);
        builder.Property(b => b.ISBN)
            .IsRequired()
            .HasMaxLength(13);

        builder.HasOne(b => b.Category)
            .WithMany(c => c.Books);
        
        builder.HasOne(b => b.Publisher)
            .WithMany(p => p.Books);
        
        builder.HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity<BookGenre>(
                l => l.HasOne(bg => bg.Genre)
                    .WithMany()
                    .HasForeignKey(bg => bg.GenreId),
                r => r.HasOne(bg => bg.Book)
                    .WithMany()
                    .HasForeignKey(bg => bg.BookId)
            );
    }
}
