using BookBeacon.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.DataSeeding;

public class PublisherSeeding
{
    public static void SeedPublishers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>().HasData(
            new Publisher { Id = 1, Name = "Diwan Publishing" }, // Published Naguib Mahfouz's works // 1
            new Publisher { Id = 2, Name = "General Egyptian Book Organization" }, // Published Taha Hussein's works // 2
            new Publisher { Id = 3, Name = "American University in Cairo Press" }, // Published Ahdaf Soueif's works and Yusuf Idris's works // 3
            new Publisher { Id = 4, Name = "Dar al-Shorouk" }, // Published Tawfiq al-Hakim's works // 4
            new Publisher { Id = 5, Name = "Egyptian-Lebanese House" }, // Published Mustafa Nasr's works // 5
            new Publisher { Id = 6, Name = "Zed Books" } // Published Nawal El Saadawi's works. // 6
            );
    }
}
