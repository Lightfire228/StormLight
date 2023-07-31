using Microsoft.EntityFrameworkCore;
 
using StormLight.Database;
using StormLight.Models;

var builder = WebApplication.CreateBuilder(args);

var config  = builder.Configuration;
var secrets = config.GetSection("Secrets").Get<Secrets>();

if (secrets == null) {
    throw new Exception("'Secrets' not found in config");
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StormLightContext>(opts => {
    opts.UseNpgsql(String.Join(";", new List<string> {
        $"Host     = {secrets.Database.Host}",
        $"Database = {secrets.Database.DbName}",
        $"Username = {secrets.Database.Username}",
        $"Password = {secrets.Database.Password}",
    }));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<StormLightContext>();
    context.Database.EnsureCreated();
}

// app.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
