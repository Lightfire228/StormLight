namespace StormLight.Models.Database.FileSystem;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Folder {

    // --- Keys

    public int Id     { get; set; }

    public int NodeId { get; set; }


    // --- Properties

    // client specific file id
    public Guid FolderId { get; set; } = new Guid();


    // --- EF bindings

}

public class FolderTypeConfiguration
    : BaseTypeConfiguration<Folder>
{
    public override void Configure(EntityTypeBuilder<Folder> builder) {

        builder
            .HasKey(x => new { x.Id, x.NodeId })
        ;

        builder
            .HasIndex(x => x.FolderId)
            .IsUnique()
        ;
    }
}

