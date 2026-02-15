using Microsoft.EntityFrameworkCore;
using NS.VehicleInventory.Application.Interfaces;
using NS.VehicleInventory.Application.Services;
using NS.VehicleInventory.Infrastructure.Data;
using NS.VehicleInventory.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VehicleInventoryDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("VehicleInventoryConnection")));

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<VehicleService>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
