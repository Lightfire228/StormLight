using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace StormLight.Database;

using ContextOptions = DbContextOptions<StormLightContext>;

public class StormLightContextFactory {


    ContextOptions   Opts            { get; set; }
    IServiceProvider ServiceProvider { get; set; }

    public StormLightContextFactory(ContextOptions opts, IServiceProvider serviceProvider) {
        Opts            = opts;
        ServiceProvider = serviceProvider;
    }

    public StormLightContext CreateDbContext(string[] args) =>
        new(
            Opts
            // ServiceProvider.GetRequiredService<ILogger<StormLightContext>>()
        )
    ;
    
}