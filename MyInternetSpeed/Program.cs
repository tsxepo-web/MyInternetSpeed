using Data.Access;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Models;
using MongoDB.Driver;
using Services;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();
var envKeys = DotEnv.Read();

var mongoConnectionString = "mongodb://tsxepo-speed-test:GYqdpxp90jK4tGxDlPSVEAnLVSNMQ1VUpLeiv7JQK9o8etVRa9OR2oCKtKpCdqqnKzAyb9d0ZAbdACDbXalyMA==@tsxepo-speed-test.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@tsxepo-speed-test@";
var mongoDatabaseName = "test";
var mongoCollectionName = "users";

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var mongoCollection = mongoDatabase.GetCollection<User>(mongoCollectionName);
builder.Services.AddSingleton<IMongoCollection<User>>(mongoCollection);
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<IUserRepository, MongodbService>();
builder.Services.AddTransient<IStatsRepository, StatsService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("default",
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

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
app.UseCors("default");
app.MapControllers();

app.Run();
