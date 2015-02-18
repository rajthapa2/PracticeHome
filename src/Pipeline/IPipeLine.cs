namespace Pipeline
{
    public interface IPipeLine
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }
}
