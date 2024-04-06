namespace SeasonPass.Core.Command;

public interface ICommandDispatcher
{
    Task<TResult> Dispatch<TCommand, TResult>(TCommand command, CancellationToken cancellation);
}
