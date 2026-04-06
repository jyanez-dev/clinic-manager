using ClinicManager.Data; // Import your DbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// --------------------------
// Configure DbContext
// --------------------------
// This registers the ClinicManagerDbContext with the DI container
// and tells EF Core to use SQL Server with the connection string
builder.Services.AddDbContext<ClinicManagerDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicManagerDB")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	// Enable OpenAPI (Swagger) in Development
	app.MapOpenApi();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

app.UseAuthorization(); // Add authorization middleware

app.MapControllers(); // Map controller endpoints

app.Run(); // Run the application