using StormLight.Database;

namespace StormLight.Server;

public class Startup {

    public IConfiguration   Configuration { get; }
    public IHostEnvironment Env           { get; }

    public Startup(IConfiguration config, IWebHostEnvironment env) {
        Configuration = config;
        Env           = env;
    }

    public void ConfigureServices(IServiceCollection services) {

    }

    public void Configure(
        IApplicationBuilder app,
        IHostEnvironment    env,
        IServiceProvider    serviceProvider,
        ILogger<Startup>    logger
    ) {



        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = serviceProvider.CreateScope()) {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<StormLightContext>();
            context.Database.EnsureCreated();
        }

        // app.

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.UseEndpoints(e => e.MapControllers());
    }


}