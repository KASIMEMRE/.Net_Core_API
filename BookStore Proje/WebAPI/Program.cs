using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataGenerator;
using WebAPI.DBOperations;
using AutoMapper;
using WebAPI.Midlewares;
using WebAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Register controllers
builder.Services.AddDbContext<BookStoreDbContext>(options => 
options.UseInMemoryDatabase(databaseName: "BookStoreDB")); // Register DbContext
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Register AutoMapper (Düzeltildi!)
builder.Services.AddSingleton<ILoggerService,DbLogger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomExceptionMiddleware();

app.MapControllers(); // Map controller endpoints

// Initialize the database with seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

app.Run();
