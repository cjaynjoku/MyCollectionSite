using Microsoft.EntityFrameworkCore;


namespace MyCollectionSite.Models;

public class CollectionContext : DbContext
{
    private readonly IConfiguration _config;

    public CollectionContext(IConfiguration config, DbContextOptions<CollectionContext> options) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_config.GetConnectionString("CollectionsDatabaseString"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectionItem>().HasData(
            new CollectionItem
            {
                Id = 1,
                Name = "Atari",
                Description = "Black hat with the classic atari logo",
                ImageURL = "https://hatcollection.blob.core.windows.net/hat-images/atari.jpg",
                Acquired = new DateTime(2018,6,23)
            },
            new CollectionItem
            {
                Id = 2,
                Name = "MyBlazorHat",
                Description = "A white hat with blazor logo",
                ImageURL = "https://hatcollection.blob.core.windows.net/hat-images/blazor.jpg",
                Acquired = new DateTime(2019, 5, 11)
            }
        );
        
    }
public DbSet<CollectionItem> CollectionItems => Set<CollectionItem>();
}
