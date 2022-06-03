using AHOY.Assessment.API;
using AHOY.Assessment.Application.Contracts;
using AHOY.Assessment.Application.Contracts.Bookings.Dtos;
using AHOY.Assessment.Application.Contracts.Hotels.Dtos;
using AHOY.Assessment.Application.Contracts.Hotels.Queries;
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

        if (dll.Contains("AHOY.Assessment."))// This should be checking on the name of dll not the path
        {
            Console.WriteLine($"loading {dll}"); // For checking which assembly loaded in run time
            builder.RegisterAssemblyModules(Assembly.LoadFile(dll));
        }
    }

});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Endpoints can be (and should be) registered in seperate files, This is only a shortcut (I don't mean using minimal APIs I think it's awesome)

app.MapPost("/Country", async ([FromBody] string name, IDispatcher dispatcher) =>
{
    await dispatcher.DispatchAsync(new AddContryCommand(name));
    return Results.NoContent();
});

app.MapPost("/Booking", async ([FromBody] BookingDto input, IDispatcher dispatcher) =>
{
    //await dispatcher.DispatchAsync(new AddContryCommand(name));
    return Results.NoContent();
});

app.MapGet("/Hotel/{id}", async (Guid id, IDispatcher dispatcher) =>
{
    var hotel = await dispatcher.DispatchAsync(new GetHotelQuery(id));
    return Results.Ok(hotel);
}).Produces<HotelDto>();

app.MapGet("/Hotels", async (string? searchTerm, IDispatcher dispatcher) =>
{
    var hotel = await dispatcher.DispatchAsync(new SearchHotelsQuery(searchTerm));
    return Results.Ok(hotel);
}).Produces<List<HotelDto>>();

app.Run();


string GetAssemblyDirectory()
{

    string codeBase = Assembly.GetExecutingAssembly().CodeBase; // Should be changed 
    UriBuilder uri = new UriBuilder(codeBase);
    string path = Uri.UnescapeDataString(uri.Path);
    return Path.GetDirectoryName(path);

}