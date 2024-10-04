using Crowdfunding_app.Services;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Crowdfunding_app;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Enable Swagger for API testing

// Retrieve the connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("CrowdfundingDB");

// Register SqlConnection as a service (for raw SQL service usage)
builder.Services.AddSingleton(new SqlConnection(connectionString));

// Register application services
builder.Services.AddScoped<CampaignService>();
builder.Services.AddScoped<UserService>();

// Optional: Use Entity Framework Core if needed instead of raw SQL
builder.Services.AddDbContext<CrowdfundingDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development mode
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Enforce HTTPS

app.UseAuthorization(); // Enable authorization, add authentication if needed

app.MapControllers(); // Map controller routes

app.Run(); // Run the application