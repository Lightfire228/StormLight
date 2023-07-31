namespace StormLight.Models.Database.FileSystem;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// A 'Node' object, which represents a file or folder on disk
public class Node {

    // --- Keys

    // Database specific id
    public int Id      { get; set; }

    // client specific 'Node' id
    // also used to store files on disk
    public Guid NodeId { get; set; } = new Guid();

    public int TypeId  { get; set; }

    // --- Properties

    public string Name { get; set; } = default!;


    // --- EF bindings

    public virtual NodeType Type   { get; set; } = default!;
    public virtual Node?    Parent { get; set; }

}

public class NodeTypeConfiguration
    : BaseTypeConfiguration<Node>
{
    public override void Configure(EntityTypeBuilder<Node> builder) {}
}