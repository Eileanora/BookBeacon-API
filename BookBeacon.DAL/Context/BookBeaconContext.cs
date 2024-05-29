using BookBeacon.DAL.Configurations;
using BookBeacon.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookBeacon.DAL.Context;

public class BookBeaconContext : IdentityDbContext<User>
{
    public BookBeaconContext(DbContextOptions<BookBeaconContext> options) : base(options)
    {
        
    }

    public BookBeaconContext()
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
    }
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCondition> BookConditions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Copy> Copies { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }    
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<User> Users { get; set; }
}
