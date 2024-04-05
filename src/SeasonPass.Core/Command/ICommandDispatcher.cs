namespace SeasonPass.Core.Command;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation);
}
