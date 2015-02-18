using StructureMap;
namespace Pipeline
{
    public interface IPipeLine
    {
        void Send(ICommand command);
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Send<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }

    public class Nothing
    {
        public static Nothing Value = new Nothing();
    }

    public interface ICommandHandlerProvider
    {
        ICommandHandler<TCommand, TResult> GetHandler<TCommand, TResult>(TCommand command);
    }

    public class CommandHandlerProvider : ICommandHandlerProvider
    {
        private readonly IContainer _container;

        public CommandHandlerProvider(IContainer container)
        {
            _container = container;
        }

        public ICommandHandler<TCommand, TResult> GetHandler<TCommand, TResult>(TCommand command)
        {
            ICommandHandler<TCommand, TResult> handler;

            handler = _container.GetInstance<ICommandHandler<TCommand, TResult>>();

            return handler;
        }
    }

    public interface ICommandHandler <in TCommand, out TResult> : ICommandHandler
    {
        TResult Handle(TCommand command);
    }

    public interface ICommandHandler
    {
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
