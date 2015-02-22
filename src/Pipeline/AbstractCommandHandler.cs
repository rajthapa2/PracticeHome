namespace Pipeline
{
    public abstract class AbstractCommandHandler<TCommand> : ICommandHandler<TCommand, Nothing>
    {
        public Nothing Handle(TCommand command)
        {
            HandleCommand(command);
            return Nothing.Value;
        }

        public abstract void HandleCommand(TCommand command);
    }
}