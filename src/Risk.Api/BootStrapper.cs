using System.Linq;
using System.Reflection;
using System.Web.Http;
using Pipeline;
using Risk.Api.Infrastructure;
using Risk.Api._Api.Risk;
using StructureMap;
using StructureMap.Configuration.DSL;
namespace Risk.Api
{
    public class BootStrapper
    {
        private readonly Registry[] _adapters;

        public BootStrapper(params Registry[] adapters)
        {
            _adapters = adapters;
        }

        public IContainer Boot(HttpConfiguration webApiConfig)
        {
            var container = Ioc(webApiConfig, _adapters);
            return container;
        }

        private Container Ioc(HttpConfiguration webApiConfig, Registry[] adapters)
        {
            webApiConfig.MapHttpAttributeRoutes();
            var container = new Container(cfg =>
            {
                var assemblyToScan = Assembly.GetAssembly(typeof(RiskController));
                var pipelineRegistry = new PipeLineRegistry(assemblyToScan);
                cfg.Scan(scanner =>
                {
                    scanner.Assembly(assemblyToScan);
                    scanner.WithDefaultConventions();
                });
                adapters.ToList().ForEach(cfg.AddRegistry);

                cfg.AddRegistry(pipelineRegistry);
            });
            

            webApiConfig.EnsureInitialized();
            webApiConfig.DependencyResolver = new StructureMapResolver(container);
            return container;
        }
    }
}
