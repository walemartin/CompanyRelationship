using CompanyRelationship.Data;
using CompanyRelationship.Interfaces;
using CompanyRelationship.Repository;
using CompanyRelationship.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DbContext with SQL Server support
builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IBranchOfficeRepository, BranchOfficeRepository>();
builder.Services.AddScoped<IBranchOfficeDeptRepository, BranchOfficeDeptRepository>();

// Register services
builder.Services.AddScoped<ICompanyService, CompanyService>();

// Add controllers and configure JSON options to handle recursive relationships correctly
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Ensure the database is created and seed initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CompanyContext>();

    try
    {
        // Apply any pending migrations
        await context.Database.MigrateAsync();

        // Seed the database
        await DatabaseSeeder.SeedAsync(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
