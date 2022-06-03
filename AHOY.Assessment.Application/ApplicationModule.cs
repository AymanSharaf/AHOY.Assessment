using AHOY.Assessment.Application.Contracts;
using AHOY.Assessment.Application.Country.CommandHandlers;
using AHOY.Assessment.Data;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AHOY.Assessment.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // This is very weird this regiteration doesn't work in DataModule but works here 
            builder.Register(componentContext =>
            {
                var serviceProvider = componentContext.Resolve<IServiceProvider>();
                var configuration = componentContext.Resolve<IConfiguration>();
                var dbContextOptions = new DbContextOptions<AHOYDbContext>(new Dictionary<Type, IDbContextOptionsExtension>());
                var optionsBuilder = new DbContextOptionsBuilder<AHOYDbContext>(dbContextOptions)
                    .UseApplicationServiceProvider(serviceProvider)
                    .UseSqlServer(configuration["AHOY:DefaultConnection"],
                        serverOptions => serverOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null));

                return optionsBuilder.Options;
            }).As<DbContextOptions<AHOYDbContext>>().InstancePerLifetimeScope();

            builder.Register(context => context.Resolve<DbContextOptions<AHOYDbContext>>())
                       .As<DbContextOptions>().InstancePerLifetimeScope();

            builder.RegisterType<AHOYDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<Dispatcher>().As<IDispatcher>();
            builder.RegisterType<AddCountryCommandHandler>().AsImplementedInterfaces();
        }
    }
}
