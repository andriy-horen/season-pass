using System.Collections.Concurrent;

namespace SeasonPass.Core.Command;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private static readonly ConcurrentDictionary<Type, CommandHandlerBase> _commandHandlers = new();

    public Task<TResult> Dispatch<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
    {
        var commandType = command.GetType();
        var handler = (CommandHandlerWrapper<TResult>)_commandHandlers.GetOrAdd(commandType, static commandType =>
        {
            var wrapperType = typeof(CommandHandlerWrapper<,>).MakeGenericType(commandType, typeof(TResult));
            var wrapper = Activator.CreateInstance(wrapperType) ?? throw new InvalidOperationException($"Could not create wrapper type for {commandType}");

            return (CommandHandlerBase)wrapper;
        });

        return handler.Handle(command, _serviceProvider, cancellationToken);
    }
}

