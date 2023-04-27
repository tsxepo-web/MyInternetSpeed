using Data.Access;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<IUserRepository, MongodbService>();
builder.Services.AddTransient<IStatsRepository, StatsService>();
builder.Services.Configure<NetworkSpeedDbSettings>(builder.Configuration.GetSection("NetworkSpeedTest"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
