using AHOY.Assessment.Application.Contracts;
using AHOY.Assessment.Core.Common;
using Microsoft.Extensions.DependencyInjection;

namespace AHOY.Assessment.Application
{
    public sealed class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            using (var scope = _serviceProvider.CreateScope())
            {
                dynamic handler = _serviceProvider.GetRequiredService(handlerType);
                await handler.HandleAsync((dynamic)command);
            }
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            using (var scope = _serviceProvider.CreateScope())
            {
                dynamic handler = _serviceProvider.GetRequiredService(handlerType);
                var result = await handler.HandleAsync((dynamic)query);

                return result;
            }
        }

        public async Task<T> DispatchAsync<T>(ICommand<T> command)
        {
            Type type = typeof(ICommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            using (var scope = _serviceProvider.CreateScope())
            {
                dynamic handler = _serviceProvider.GetRequiredService(handlerType);
                var result = await handler.HandleAsync((dynamic)command);

                return result;
            }
        }
    }
}
