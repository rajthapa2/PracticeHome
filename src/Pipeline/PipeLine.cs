namespace Pipeline
{
    public class PipeLine : IPipeLine
    {
        private readonly ICommandHandlerProvider _commandHandlerProvider;

        public PipeLine( ICommandHandlerProvider commandHandlerProvider)
        {
            _commandHandlerProvider = commandHandlerProvider;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            Send<TCommand, Nothing>(command);
        }

        public TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            return _commandHandlerProvider.GetHandler<TCommand, TResult>(command)
                .Handle(command);
        }
    }
}