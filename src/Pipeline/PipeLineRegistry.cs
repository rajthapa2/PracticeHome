using System.Reflection;
using Risk.Api._Api.Risk;
using StructureMap.Configuration.DSL;

namespace Pipeline
{
    public class PipeLineRegistry  :Registry
    {
        public PipeLineRegistry(Assembly assemblyToScan)
        {
            For<IPipeLine>().Use<PipeLine>();
            For<ICommandHandlerProvider>().Use<CommandHandlerProvider>();
            Scan(scanner =>
            {
                scanner.WithDefaultConventions();
                scanner.AddAllTypesOf(typeof (ICommandHandler<,>));
                scanner.Assembly(assemblyToScan);            
            });
        }
    }
}