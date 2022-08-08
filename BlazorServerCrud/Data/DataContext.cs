using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Game> Games => Set<Game>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 1,
                Name = "The Witcher 3",
                Developer = "CD Projeck Red",
                Release = new DateTime(2014, 2, 23)
            },
            new Game
            {
                Id = 2,
                Name = "The Last of Us Part 2",
                Developer = "Naughty Dog",
                Release = new DateTime(2020, 7, 20)
            });
        }
    }
}
