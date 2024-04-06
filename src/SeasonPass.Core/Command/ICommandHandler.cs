namespace SeasonPass.Core.Command;

public interface ICommandHandler<in TCommand, TResult>
{
    Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
}
