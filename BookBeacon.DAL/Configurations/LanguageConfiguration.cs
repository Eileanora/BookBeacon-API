using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(b => b.Books)
            .WithMany(l => l.Languages);
    }
}
