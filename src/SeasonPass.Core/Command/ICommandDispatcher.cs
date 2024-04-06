namespace SeasonPass.Core.Command;

public interface ICommandDispatcher
{
    Task<TResult> Dispatch<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);
}
