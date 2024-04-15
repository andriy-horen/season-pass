using Microsoft.Extensions.DependencyInjection;
using SeasonPass.Core.Command;

namespace SeasonPass.Core.Command;

public abstract class CommandHandlerBase
{
    public abstract Task<object?> Handle(
        object command,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    );
}

public abstract class CommandHandlerWrapper<TResult> : CommandHandlerBase
{
    public abstract Task<TResult> Handle(
        ICommand<TResult> command,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    );
}

public class CommandHandlerWrapper<TCommand, TResult> : CommandHandlerWrapper<TResult>
    where TCommand : ICommand<TResult>
{
    public override Task<TResult> Handle(
        ICommand<TResult> command,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    )
    {
        return serviceProvider
            .GetRequiredService<ICommandHandler<TCommand, TResult>>()
            .Handle((TCommand)command, cancellationToken);
    }

    public override async Task<object?> Handle(
        object command,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken
    )
    {
        return await Handle((ICommand<TResult>)command, serviceProvider, cancellationToken).ConfigureAwait(false);
    }
}
