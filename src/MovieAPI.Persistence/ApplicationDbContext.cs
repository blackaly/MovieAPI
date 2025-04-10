using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieAPI.src.MovieAPI.Domain.Entities;

namespace MovieAPI.src.MovieAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Eposide> Eposides{ get; set; }
        public DbSet<SeriesDirectors> SeriesDirectors { get; set; }
        public DbSet<MovieDirectors> MovieDirectors { get; set; }
        public DbSet<SeriesActor> SeriesActors { get; set; }
        public DbSet<MovieActors> MovieActors { get; set; }
    }
}
