using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
{
    public void Configure(EntityTypeBuilder<MembershipType> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(m => m.Price)
            .IsRequired();

        builder.HasMany(b => b.Users)
            .WithOne(m => m.MembershipType);
    
        builder.Property(m => m.Price)
            .HasColumnType("decimal(18,2)");
    }
}
