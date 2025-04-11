using System.Collections;

var builder = WebApplication.CreateBuilder(args);

foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
    Console.WriteLine(">>> {0} = {1}", item.Key, item.Value);

// Add services to the container.

builder.Services.AddControllers();

//reads docker run args and overrides settings
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddCommandLine(args);
    //.AddEnvironmentVariables("TestApp_");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
