using VisionHub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services with the connection string retrieved from appsettings.json
builder.Services.AddScoped<ArtworkService>(provider =>
    new ArtworkService(builder.Configuration.GetConnectionString("VisionHubDB")));
builder.Services.AddScoped<CommentService>(provider =>
    new CommentService(builder.Configuration.GetConnectionString("VisionHubDB")));
builder.Services.AddScoped<UserService>(provider =>
    new UserService(builder.Configuration.GetConnectionString("VisionHubDB")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();