namespace AHOY.Assessment.Core.Common
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResualt> where TCommand : ICommand<TResualt>
    {
        Task<TResualt> HandleAsync(TCommand command);
    }
}
