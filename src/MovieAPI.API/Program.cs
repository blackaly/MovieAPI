using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieAPI.src.MovieAPI.Domain.Entities;
using MovieAPI.src.MovieAPI.Infrastructure.Persistence;
using MovieAPI.src.MovieAPI.Application.Interfaces.Services;
using MovieAPI.src.MovieAPI.Application.Services;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAPI.Infrastructure.Authentication;
using MovieAPI.Domain.Interface.Repository;
using MovieAPI.Infrastructure.Repository;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Connection");

// Validate JWT configuration
var jwtKey = builder.Configuration["JWT:Key"];
var jwtIssuer = builder.Configuration["JWT:Issuer"];
var jwtAudience = builder.Configuration["JWT:Audience"];

if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
{
    throw new Exception("JWT configuration is missing or incomplete in appsettings.json. " +
                        "Please make sure JWT:Key, JWT:Issuer, and JWT:Audience are properly configured.");
}

// to tell him that we will use the identity in our application
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
// To give the dbContext the connection string
builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Configure JwtSettings from appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));

// Register JwtSettings as a service
builder.Services.AddSingleton(sp => 
{
    var options = sp.GetRequiredService<IOptions<JwtSettings>>();
    return options.Value;
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// To add authentication to all controller.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestApiJWT", Version = "v1" });
});
        

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register JwtGenerator
builder.Services.AddScoped<JwtGenerator>();

// Services Injection
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ISeriesService, SeriesService>();
builder.Services.AddTransient<IEposideService, EposideService>();
builder.Services.AddTransient<IDirectorService, DirectorService>();


// Repository Injection - changed from Singleton to Scoped to match DbContext lifetime
builder.Services.AddScoped<IDirectorRepo, DirectorRepository>();
builder.Services.AddScoped<IEposideRepo, EposideRepository>();
builder.Services.AddScoped<ISeriesRepo, SeriesRepository>();
builder.Services.AddScoped<IMovieRepo, MovieRepository>();
builder.Services.AddScoped<IGenreRepo, GenreRepository>();




builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Only use HTTPS redirection in production
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

// Add a default route to test if the API is running
app.MapGet("/", () => "Movie API is running!");

app.MapControllers();

app.Run();
