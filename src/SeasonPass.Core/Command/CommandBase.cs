namespace SeasonPass.Core.Command;

public abstract class CommandBase<TResult> : ICommand<TResult>
{
    public Guid Id { get; }

    protected CommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        this.Id = id;
    }
}