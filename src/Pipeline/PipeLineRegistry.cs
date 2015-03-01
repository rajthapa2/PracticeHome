using System.Globalization;
using System.Reflection;
using FluentValidation;
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
                scanner.AddAllTypesOf(typeof (IValidator<>));

                ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
                FluentValidationCamelCase();
                scanner.Assembly(assemblyToScan);            
            });
        }
        private static void FluentValidationCamelCase()
        {
            ValidatorOptions.PropertyNameResolver = (type, info, arg3) =>
                info.Name.ToString(CultureInfo.InvariantCulture).ToCamelCase();
        }
    }
}