using Microsoft.Extensions.DependencyInjection;

namespace SeasonPass.Core.Command;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public Task<TResult> Dispatch<TCommand, TResult>(TCommand command, CancellationToken cancellation)
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();

        return handler.Handle(command, cancellation);
    }
}

