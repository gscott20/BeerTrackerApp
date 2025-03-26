using Scalar.AspNetCore;
using BeerTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;
using BeerTrackerAPI.Configurations;
using AutoMapper;
using AutoMapper.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("BeerTrackerAppDbConnection");
builder.Services.AddDbContext<BeerTrackerDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperConfig)); // Change this line

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();