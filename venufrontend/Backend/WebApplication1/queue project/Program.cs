using Microsoft.EntityFrameworkCore;
using QueueManagementAPI;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// ================================
// ✅ 1. ADD SERVICES
// ================================

// Add Controllers
builder.Services.AddControllers();

// Add Swagger (API Testing UI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable CORS (for Angular frontend)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// ================================
// ✅ 2. MIDDLEWARE PIPELINE
// ================================

// Swagger (only in development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors("AllowAll");

// HTTPS redirection
app.UseHttpsRedirection();

// Authorization (optional for now)
app.UseAuthorization();

// Map Controllers
app.MapControllers();

// Run app
app.Run();