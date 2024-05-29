using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(15);
        
        builder.HasMany(b => b.Users)
            .WithOne(u => u.Gender);
    }
}
