using AHOY.Assessment.API;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new APIModule());
    foreach (string dll in Directory.GetFiles(GetAssemblyDirectory(), "*.dll"))
    {
        Console.WriteLine($"loading {dll}");
        Assembly.LoadFrom(dll);
        builder.RegisterAssemblyModules(Assembly.LoadFile(dll));
    }

});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();

string GetAssemblyDirectory()
{

    string codeBase = Assembly.GetExecutingAssembly().CodeBase; // Should be changed 
    UriBuilder uri = new UriBuilder(codeBase);
    string path = Uri.UnescapeDataString(uri.Path);
    return Path.GetDirectoryName(path);

}