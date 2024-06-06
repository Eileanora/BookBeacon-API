using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookBeacon.DAL.Configurations;

public class BookConditionConfiguration : IEntityTypeConfiguration<BookCondition>
{
    public void Configure(EntityTypeBuilder<BookCondition> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasMany(b => b.Copies)
            .WithOne(c => c.Condition);
    }
}
