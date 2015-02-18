namespace Pipeline
{
    public interface IPipeLine
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }

    public abstract class AbstractCommandHandler<TCommand> : ICommandHandler<TCommand, Nothing>
    {
        public Nothing Handle(TCommand command)
        {
            HandleCommand(command);
            return Nothing.Value;
        }

        public abstract void HandleCommand(TCommand message);
    }
}
