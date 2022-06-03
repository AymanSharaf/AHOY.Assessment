using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AHOY.Assessment.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AHOYDbContextFactory>().AsImplementedInterfaces();
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var options = new DbContextOptionsBuilder<AHOYDbContext>();
                options.UseSqlServer(config["AHOY:DefaultConnection"]);

                return new AHOYDbContext(options.Options);
            }).AsSelf().InstancePerLifetimeScope();

        }
    }
}
