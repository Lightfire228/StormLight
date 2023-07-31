namespace StormLight.Models.Database.FileSystem;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class File {

    // --- Keys

    public int Id { get; set; }

    // --- Properties


    // --- EF Bindings

    public virtual Node Node     { get; set; } = default!;
    public virtual Folder Parent { get; set; } = default!;

}

public class FileTypeConfiguration
    : BaseTypeConfiguration<File>
{
    public override void Configure(EntityTypeBuilder<File> builder) {}
}

