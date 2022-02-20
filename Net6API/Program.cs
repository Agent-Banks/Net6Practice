using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Net6API.Data;
using Net6API.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Net6APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Net6APIContext")));

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V - 1.0.0",
        Title = "Net6 Practice API",
        Description = "An ASP.NET Core Web API for personal practice to implement new ideas",       
        Contact = new OpenApiContact
        {
            Name = "Cody Banks",
            Url = new Uri("https://example.com/contact")
        }        
    });
});

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

app.Run();
