using CitiesManager.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.WebAPI.DatabaseContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions options) : base(options) { }
        
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City() { CityID=Guid.Parse("79635EDC-F017-4057-BF53-E066C4E327DE"), CityName="New York"});
            modelBuilder.Entity<City>().HasData(new City() { CityID = Guid.Parse("28897FF4-3654-4218-AAC7-539EE17CB5BC"), CityName = "London" });
            modelBuilder.Entity<City>().HasData(new City() { CityID = Guid.Parse("4B3CBBA2-A0EB-4EDA-B267-1D3115357CF8"), CityName = "Boston" });

        }

    }
}
