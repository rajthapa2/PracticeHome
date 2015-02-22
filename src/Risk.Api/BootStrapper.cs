using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using Pipeline;
using Risk.Api.Adpaters;
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

            var cors = new EnableCorsAttribute("*", "*", "GET,POST");
            webApiConfig.EnableCors(cors);
            webApiConfig.EnsureInitialized();
            return container;
        }

        private Container Ioc(HttpConfiguration webApiConfig, IEnumerable<Registry> adapters)
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
                webApiConfig.Filters.Add(new ExceptionResponseMapAttribute());

                cfg.AddRegistry(pipelineRegistry);
            });
            webApiConfig.DependencyResolver = new StructureMapResolver(container);
            return container;
        }
    }
}
