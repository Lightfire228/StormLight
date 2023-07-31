namespace StormLight.Database;

using Microsoft.EntityFrameworkCore;
using StormLight.Database;
using StormLight.Models;
using StormLight.Models.Database;
using StormLight.Models.Database.FileSystem;

public class StormLightContext
    : StormLightTables
{
    public StormLightContext(DbContextOptions<StormLightContext> opts)
        : base(opts)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyTypeConfiguration(typeof(BaseTypeConfiguration<>).Assembly);
    }


}