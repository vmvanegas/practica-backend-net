using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PracticaBackendNet.Automappers;
using PracticaBackendNet.DTOs;
using PracticaBackendNet.Models;
using PracticaBackendNet.Repository;
using PracticaBackendNet.Services;
using PracticaBackendNet.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddKeyedScoped<ICommonBeerService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");

// HttpClient Service JsonPlaceHolder
builder.Services.AddHttpClient<IPostService, PostService>(c => {
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});

// Repository

builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();

// Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

// Fluent Validators
builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();
builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();

// Mappers

builder.Services.AddAutoMapper(typeof(MappingProfile));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
