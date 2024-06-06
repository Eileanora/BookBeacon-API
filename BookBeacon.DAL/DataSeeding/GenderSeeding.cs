using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class GenderSeeding
{
    public static void SeedGenders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1, Name = "Female"},
            new Gender { Id = 2, Name = "Male" }
        );
    }

}
