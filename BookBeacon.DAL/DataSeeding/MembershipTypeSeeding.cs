using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class MembershipTypeSeeding
{
    public static void SeedMembershipTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MembershipType>().HasData(
            new MembershipType { Id = 1, Name = "Free", Price = 0, DurationInMonths = 0, DiscountRate = 0 },
            new MembershipType { Id = 2, Name = "Monthly", Price = 30, DurationInMonths = 1, DiscountRate = 10 },
            new MembershipType { Id = 3, Name = "Quarterly", Price = 90, DurationInMonths = 3, DiscountRate = 15 },
            new MembershipType { Id = 4, Name = "Annual", Price = 300, DurationInMonths = 12, DiscountRate = 20 }
        );
    }
}
