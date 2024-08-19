using MCPlaces_Backend.Data;
using MCPlaces_Backend.Models.ApiResponse;
using MCPlaces_Backend.Models.ApiResponse.Interfaces;
using MCPlaces_Backend.Repository.PlaceRepository;
using MCPlaces_Backend.Repository.PlaceRepository.Interfaces;
using MCPlaces_Backend.Repository.ServerRepository;
using MCPlaces_Backend.Repository.ServerRepository.Interfaces;
using MCPlaces_Backend.Utilities.ActionFilters;
using MCPlaces_Backend.Utilities.ActionFilters.Interfaces;
using MCPlaces_Backend.Utilities.Mappers;
using MCPlaces_Backend.Utilities.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => 
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

// Places Dependencies.
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceMapper, PlaceMapper>();
// Server Dependencies.
builder.Services.AddScoped<IServerRepository, ServerRepository>();
builder.Services.AddScoped<IServerMapper, ServerMapper>();
// General Dependencies.
builder.Services.AddScoped<IApiResponse, ApiResponse>();
builder.Services.AddScoped<IModelValidationActionFilter, ModelValidationActionFilter>();

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.Configure<ApiBehaviorOptions>(options => 
{
    options.SuppressModelStateInvalidFilter = true;
});

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
