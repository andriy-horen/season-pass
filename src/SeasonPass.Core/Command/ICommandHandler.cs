namespace SeasonPass.Core.Command;

public interface ICommandHandler<in TCommand, TCommandResult>
{
    Task<TCommandResult> Handle(TCommand command, CancellationToken cancellation);
}
