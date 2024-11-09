using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain.Entities;

namespace OnlineCinema.Domain;

public class AppDbContext : IdentityDbContext<User>
{
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Advertising> Advertisings { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<News> News { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
