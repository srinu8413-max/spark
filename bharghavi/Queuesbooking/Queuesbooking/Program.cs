using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Queuesbooking.Data;
using Queuesbooking.service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add DbContext
builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//service for query
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Auth>();
// ✅ Add Controllers
builder.Services.AddControllers();

// ✅ JWT Setup
var key = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

// ✅ Authorization
builder.Services.AddAuthorization();

// ✅ CORS (Angular connection)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// ✅ Middleware
app.UseCors("AllowAll");

app.UseAuthentication(); // IMPORTANT
app.UseAuthorization();

app.MapControllers();

app.Run();