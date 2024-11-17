using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SwoyerOrbiloUniverse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WikiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WikiDatabase")));

// Add controller services
builder.Services.AddControllers();
builder.Services.AddScoped<WikiService>();


// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline for Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Wiki API v1");
        options.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}

// Map controller routes
app.MapControllers();

app.Run();