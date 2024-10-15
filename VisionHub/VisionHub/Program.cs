using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VisionHub.Services;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy for localhost:3000
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container
builder.Services.AddScoped<ArtworkService>(provider =>
    new ArtworkService(builder.Configuration.GetConnectionString("VisionHubDB")));
builder.Services.AddScoped<CommentService>(provider =>
    new CommentService(builder.Configuration.GetConnectionString("VisionHubDB")));
builder.Services.AddScoped<UserService>(provider =>
    new UserService(builder.Configuration.GetConnectionString("VisionHubDB")));
builder.Services.AddScoped<CategoryService>(provider =>
    new CategoryService(builder.Configuration.GetConnectionString("VisionHubDB")));


var secretKey = builder.Configuration["Jwt:SecretKey"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development mode
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost3000");

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization(); // Add authorization middleware

app.MapControllers(); // Map controller routes
app.UseStaticFiles();
app.Run(); // Run the application
