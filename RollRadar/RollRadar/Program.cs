using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RollRadar.Servies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Add support for controllers and APIs

// Register your services for dependency injection
builder.Services.AddScoped<ScoreService>();
builder.Services.AddScoped<BowlingAlleyService>();
builder.Services.AddScoped<BowlingBallService>();
builder.Services.AddScoped<UserService>();

// Add database connection string as a configuration
string connectionString = "Server=localhost\\SQLEXPRESS;Database=BowlingDB;Integrated Security=True;";
builder.Services.AddSingleton(connectionString); // Register the connection string

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Enable detailed error pages in development
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseAuthorization(); // Enable authorization middleware

app.MapControllers(); // Map controller routes

app.Run(); // Run the application