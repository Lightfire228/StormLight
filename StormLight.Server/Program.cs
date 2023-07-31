using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace StormLight.Server;

public class Program {
    public static Task Main(string[] args) =>
        WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build()
            .RunAsync()
    ;
}

