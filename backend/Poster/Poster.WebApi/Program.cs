using Poster.Application.Filters;
using Poster.Infrastructure;
using Poster.Application;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<ExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    var filePath = Path.Combine(AppContext.BaseDirectory, "Poster.WebApi.xml");
    options.IncludeXmlComments(filePath);
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddBase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options =>
{
    options.WithOrigins(builder.Configuration.GetSection("Cors").Get<string[]>())
        .AllowAnyHeader()
        .AllowAnyMethod();
});

app.Run();
