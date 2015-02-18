namespace Pipeline
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<in TCommand, out TResult> : ICommandHandler
    {
        TResult Handle(TCommand command);
    }
}