using Microsoft.EntityFrameworkCore;
using NTier_ECommerce_Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NTier_ECommerce_DAL.Database
{
    public class Context : IdentityDbContext<ApplicationUser> /*DbContext instead of this */
    {
        string connectionString = "server = DESKTOP-57R498V\\SQLEXPRESS01;database = ntierecommerce; integrated security = true;TrustServerCertificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors_Movie>().HasKey(x => new
            {
                x.ActorId,
                x.MovieId
            });
            modelBuilder.Entity<Actors_Movie>().HasOne(x => x.Movie).WithMany(x => x.Actors_Movies).HasForeignKey(x => x.MovieId);
            modelBuilder.Entity<Actors_Movie>().HasOne(x => x.Actor).WithMany(x => x.Actors_Movies).HasForeignKey(x => x.ActorId);
            base.OnModelCreating(modelBuilder);
            /* Explanation 
* HasKey => It is the method by which the combined key is determined.

*HasOne and WithMany: Specifies relationships. The Actor_Movie table is associated with both a Movie and an Actor. 
These methods are important in determining and directing the relationship.

*HasForeignKey: Specifies foreign key relationships.*/
        }

        // for creating table on database
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actors_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
