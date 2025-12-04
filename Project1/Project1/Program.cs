using Microsoft.EntityFrameworkCore;
using Project1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi(); // default in .NET 8
builder.Services.AddSwaggerGen(); // Swashbuckle

// --- Old MySQL configuration (commented out) ---
// builder.Services.AddDbContext<ProductDbContext>(options =>
//     options.UseMySql(
//         builder.Configuration.GetConnectionString("DefaultConnection"),
//         new MySqlServerVersion(new Version(8, 0, 0)) 
//     )
// );

// --- New SQLite configuration ---
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // exposes /openapi/v1.json
    app.UseSwagger(); // exposes /swagger
    app.UseSwaggerUI(); // interactive UI
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
