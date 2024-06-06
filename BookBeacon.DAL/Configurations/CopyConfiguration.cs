using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class CopyConfiguration : IEntityTypeConfiguration<Copy>
{
    public void Configure(EntityTypeBuilder<Copy> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Location)
            .HasMaxLength(50);
        
        builder.Property(c => c.Notes)
            .HasMaxLength(100);

        builder.HasOne(c => c.Book)
            .WithMany(b => b.Copies);

        builder.HasOne(c => c.Condition)
            .WithMany(c => c.Copies);
        
        builder.HasMany(c => c.Reservations)
            .WithOne(r => r.Copy);
        
        builder.HasOne(c => c.Language)
            .WithMany(l => l.Copies);
    }
}
