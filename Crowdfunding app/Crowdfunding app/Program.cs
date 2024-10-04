using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Retrieve the connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("CrowdfundingDB");

// Register SqlConnection as a service
builder.Services.AddSingleton(new SqlConnection(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();