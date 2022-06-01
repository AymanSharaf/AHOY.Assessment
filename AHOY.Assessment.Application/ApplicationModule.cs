using AHOY.Assessment.Application.Contracts;
using Autofac;

namespace AHOY.Assessment.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Dispatcher>().As<IDispatcher>();
        }
    }
}
