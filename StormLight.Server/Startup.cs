

using Minio;
using Minio.DataModel;
using StormLight.Models;
using StormLight.Storage;
using StormLight.Storage.S3;

public static class Startup {

    public static void Services(WebApplicationBuilder builder) {

        var secrets = builder.Configuration.GetSection("Secrets").Get<Secrets>();

        ArgumentNullException.ThrowIfNull(secrets);
        ArgumentNullException.ThrowIfNull(secrets.Storage);

        var services = builder.Services;

        services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMinio(client => 
            client
                .WithEndpoint   (secrets.Storage.Endpoint)
                .WithCredentials(secrets.Storage.AccessKey, secrets.Storage.SecretKey)
                .Build()
        );

        
        services.AddScoped<IStorage<ProgressReport>, S3Storage>();
    }

}