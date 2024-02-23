using Asp.Versioning;
using CitiesManager.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(config =>
{
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
});
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddEndpointsApiExplorer(); // Generates descriptions for all endpoints
builder.Services.AddSwaggerGen(options=>options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,"api.xml"))); // Generates OpenAPI specification
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(); //Creates swagger.json
app.UseSwaggerUI(); // Generated Swagger UI for testing all endpoints

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
