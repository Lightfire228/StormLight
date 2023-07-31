namespace StormLight.Models.Database.FileSystem;

using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class NodeType {

    public int Id { get; set; }

    public string DisplayName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Code        { get; set; } = default!;
}

public class NodeTypeTypeConfiguration
    : BaseTypeConfiguration<NodeType>
{
    public override void Configure(EntityTypeBuilder<NodeType> builder) {
        builder
            .HasIndex(x => x.Code)
            .IsUnique()
        ;

        var test = typeof(NodeTypeConstants)
            .GetProperties()
            .Where (p => p.CanRead && p.PropertyType == typeof(NodeType))
            .Select(p => p.GetValue(typeof(NodeTypeConstants)) as NodeType)
        ;

        foreach (var x in test) {
            if (x == null) {
                Console.WriteLine($">>>>>>>>>>>> null");
            }
            else {
                Console.WriteLine($">>>>>>>>>>>> value: {x.Code}");
            }
        }

        // builder.HasData(
        //     typeof(NodeTypeConstants)
        //         .GetProperties()
        //         .Where (p => p.CanRead && p.PropertyType == typeof(NodeType))
        //         .Select(p => p.GetValue(typeof(NodeTypeConstants)) as NodeType)!
        // );

    }
}

public static class NodeTypeConstants {

    public static readonly NodeType LocalStorage = new() {
        Id          = 1,
        DisplayName = "Local Storage",
        Description = "Storage mounted on the local file system",
        Code        = "local",
        
    };

    public static readonly NodeType NetworkStorage = new() {
        Id          = 2,
        DisplayName = "Network Storage",
        Description = "Storage over a network file share or other local network storage",
        Code        = "network",
    };

    // public static readonly NodeType Azure = new() {
    //     Id          = 3,
    //     DisplayName = "Azure Blob Storage",
    //     Description = "",
    //     Code        = "azure",
    // };

    // public static readonly NodeType S3 = new() {
    //     Id          = 4,
    //     DisplayName = "AZW S3",
    //     Description = "",
    //     Code        = "azure",
    // };
}