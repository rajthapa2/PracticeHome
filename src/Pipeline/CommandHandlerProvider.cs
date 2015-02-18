using StructureMap;

namespace Pipeline
{
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
            var handler = _container.GetInstance<ICommandHandler<TCommand, TResult>>();

            return handler;
        }
    }
}