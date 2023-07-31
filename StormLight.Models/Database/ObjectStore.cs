namespace StormLight.Models.Database.FileSystem;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// Represents a storage location
public class ObjectStore {

    // Database specific id
    public int Id { get; set; }


    public string Name { get; set; } = default!;
}

public class ObjectStoreTypeConfiguration
    : BaseTypeConfiguration<ObjectStore>
{
    public override void Configure(EntityTypeBuilder<ObjectStore> builder) {}
}