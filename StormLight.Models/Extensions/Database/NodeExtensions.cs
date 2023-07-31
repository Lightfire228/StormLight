namespace StormLight.Models.Extensions.Database;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using StormLight.Models.Database.FileSystem;

public static class NodeExtensions {

    public static string GetPath(this Node node) {

        List<string> path = new() { node.Name };

        // while (var parent = node.Parent)

        return null!;
    }
}