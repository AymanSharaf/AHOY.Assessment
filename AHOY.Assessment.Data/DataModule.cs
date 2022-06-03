using Autofac;

namespace AHOY.Assessment.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AHOYDbContextFactory>().AsImplementedInterfaces();

            //builder.Register(componentContext =>
            //{
            //    var serviceProvider = componentContext.Resolve<IServiceProvider>();
            //    var configuration = componentContext.Resolve<IConfiguration>();
            //    var dbContextOptions = new DbContextOptions<AHOYDbContext>(new Dictionary<Type, IDbContextOptionsExtension>());
            //    var optionsBuilder = new DbContextOptionsBuilder<AHOYDbContext>(dbContextOptions)
            //        .UseApplicationServiceProvider(serviceProvider)
            //        .UseSqlServer(configuration["AHOY:DefaultConnection"],
            //            serverOptions => serverOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null));

            //    return optionsBuilder.Options;
            //}).As<DbContextOptions<AHOYDbContext>>().InstancePerLifetimeScope();

            //builder.Register(context => context.Resolve<DbContextOptions<AHOYDbContext>>())
            //           .As<DbContextOptions>().InstancePerLifetimeScope();

            //builder.RegisterType<AHOYDbContext>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.Register(c =>
            //{
            //    var config = c.Resolve<IConfiguration>();
            //    Console.WriteLine("Registering");
            //    var options = new DbContextOptionsBuilder<AHOYDbContext>();
            //    options.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=AHOYDB;User Id=sa;Password=P@ssword;");

            //    return new AHOYDbContext(options.Options);
            //}).AsSelf().InstancePerDependency();

            builder.RegisterType<DatabaseInitializer>().AsImplementedInterfaces(); // This is only becasue there is an issue in loading Microsoft.Data.SqlClient dynmaiclly in runtime
            // The other solution is to add package Microsoft.EntityFrameworkCore.SqlServer in API
            // Which sadly I did in the end to make Update-Database and Remove-Migrations work 
        }
    }
}
