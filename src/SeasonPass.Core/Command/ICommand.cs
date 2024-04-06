namespace SeasonPass.Core.Command;

public interface ICommand<out TResult>
{
    Guid Id { get; }
}
