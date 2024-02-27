using Libreria.Application.Middlewares;
using Libreria.Application.Services;
using Libreria.Application.Abstractions.Services;
using Libreria.Models.Repository;
using Libreria.Models.Context;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer("data source=localhost;Initial catalog=libreria;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True;Trusted_Connection=True;", options =>
    {
        options.EnableRetryOnFailure();
    });
});
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<BookRepository>();

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<CategoryRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();
app.UseMiddleware<MiddlewareExample>();

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
