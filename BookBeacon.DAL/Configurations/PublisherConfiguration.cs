using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.HasMany(b => b.Books)
            .WithOne(p => p.Publisher);
    }
}
