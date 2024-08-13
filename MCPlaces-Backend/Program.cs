using MCPlaces_Backend.Data;
using MCPlaces_Backend.Models.ApiResponse;
using MCPlaces_Backend.Models.ApiResponse.Interfaces;
using MCPlaces_Backend.Repository.PlaceRepository;
using MCPlaces_Backend.Repository.PlaceRepository.Interfaces;
using MCPlaces_Backend.Utilities.Mappers;
using MCPlaces_Backend.Utilities.Mappers.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<IPlaceMapper, PlaceMapper>();
builder.Services.AddScoped<IApiResponse, ApiResponse>();

builder.Services.AddControllers().AddNewtonsoftJson();
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
