namespace StormLight.Database;

using System.Reflection;
using Microsoft.EntityFrameworkCore;

public static class Extensions {

    /// Finds all classes with the `IEntityTypeConfiguration` interface, and
    /// applies each `OnModelCreating()`
    public static ModelBuilder ApplyTypeConfiguration(this ModelBuilder builder, Assembly assembly) {
        var types = assembly
            .GetTypes()
            .Where(t => 
                t.GetInterfaces()
                .Any(i => 
                    i.IsGenericType && (
                        // i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
                        true
                    )
                )
                && !t.IsInterface
                && !t.IsAbstract
            )
        ;

        foreach (var t in types) {

            Console.WriteLine($">>>>>>>>>>>> name: {t.Name}");

            dynamic? config = Activator.CreateInstance(t);

            if (config == null) {
                throw new Exception($"Unable to construct instance of {t.Name}");
            }

            builder.ApplyConfiguration(config);
        }

        return builder;
    }
}