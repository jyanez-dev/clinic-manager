using ClinicManager.Data; // Import your DbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --------------------------
// Configure DbContext
// --------------------------
builder.Services.AddDbContext<ClinicManagerDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicManagerDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	// Enable Swagger UI in Development
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

app.UseAuthorization(); // Add authorization middleware

app.MapControllers(); // Map controller endpoints

app.Run(); // Run the application