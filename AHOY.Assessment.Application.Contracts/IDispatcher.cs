using AHOY.Assessment.Core.Common;

namespace AHOY.Assessment.Application.Contracts
{
    public interface IDispatcher
    {
        Task DispatchAsync(ICommand command);

        Task<T> DispatchAsync<T>(ICommand<T> command);

        Task<T> DispatchAsync<T>(IQuery<T> query);
    }
}
