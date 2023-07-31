namespace StormLight.Database;

using Microsoft.EntityFrameworkCore;
using StormLight.Models;
using StormLight.Models.Database.FileSystem;

public abstract class StormLightTables
    : DbContext
{
    public StormLightTables(DbContextOptions<StormLightContext> opts)
        : base(opts)
    {}

    public DbSet<NodeType> Nodes { get; set; } = default!;

    public DbSet<TodoItem> TodoItems { get; set; } = default!;

}