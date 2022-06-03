using AHOY.Assessment.API;
using AHOY.Assessment.Application.Contracts;
using AHOY.Assessment.Core.Countries.Commands;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new APIModule());
    foreach (string dll in Directory.GetFiles(GetAssemblyDirectory(), "*.dll"))
    {
        Assembly.LoadFrom(dll);

        if (dll.Contains("AHOY.Assessment."))
        {
            Console.WriteLine($"loading {dll}");
            builder.RegisterAssemblyModules(Assembly.LoadFile(dll));
        }
    }

});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => { return "Hello World"; });

app.MapGet("/hi", () => { return "Hello World"; });

app.MapPost("/Country", async ([FromBody] string name, IDispatcher dispatcher) =>
{
    await dispatcher.DispatchAsync(new AddContryCommand(name));
    return Results.NoContent();
});

app.Run();


string GetAssemblyDirectory()
{

    string codeBase = Assembly.GetExecutingAssembly().CodeBase; // Should be changed 
    UriBuilder uri = new UriBuilder(codeBase);
    string path = Uri.UnescapeDataString(uri.Path);
    return Path.GetDirectoryName(path);

}