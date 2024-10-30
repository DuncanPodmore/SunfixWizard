using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SunfixBackend.Data;
using SunfixBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Solar Quoting API",
        Description = "API for managing solar quotes and parts"
    });
});


// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Solar Quoting API V1");
        c.RoutePrefix = string.Empty;  // Set Swagger UI to launch at the root URL
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();