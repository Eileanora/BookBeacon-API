using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();
        builder.Property(a => a.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(a => a.LastName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(a => a.Biography)
            .HasMaxLength(500);

        builder.HasMany(a => a.Books)
            .WithOne(b => b.Author);
    }
}
