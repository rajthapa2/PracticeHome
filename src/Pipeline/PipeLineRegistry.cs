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
            Scan(scanner=>scanner.AddAllTypesOf(typeof(ICommand)));
//            Scan(scanner=>scanner.AddAllTypesOf(typeof(ICommandHandler)));
//            Scan(scanner => scanner.AddAllTypesOf(typeof (ICommandHandler<,>)));
//            Scan(scanner => scanner.Assembly(assemblyToScan));            
//            Scan(scanner=> scanner.WithDefaultConventions());
            For<ICommandHandler<CreateRisk, Nothing>>().Use<CreateRiskHandler>();
        }
    }
}