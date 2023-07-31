using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StormLight.Models.Database;

public abstract class BaseTypeConfiguration<T>
    : IEntityTypeConfiguration<T>
    where T : class
{
    public abstract void Configure(EntityTypeBuilder<T> builder);
}