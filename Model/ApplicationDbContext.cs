using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Model.Domains;

namespace MovieAPI.Model
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
    }
}
