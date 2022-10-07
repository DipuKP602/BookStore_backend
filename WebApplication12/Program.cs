using WebApplication12.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<BookDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
});

builder.Services.AddTransient<IBookRepository,BookRepositoryImpl>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepositoryImpl>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
