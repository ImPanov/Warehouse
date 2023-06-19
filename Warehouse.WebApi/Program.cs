using Microsoft.EntityFrameworkCore;
using Pckt.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? sqlServerConnection = builder.Configuration
 .GetConnectionString("WarehouseConnection");

builder.Services.AddWarehouseContext(sqlServerConnection);
builder.Services.AddCors();
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
app.UseCors(builder => builder.WithOrigins("https://localhost:7189/"));
app.UseAuthorization();

app.MapControllers();

app.Run();
