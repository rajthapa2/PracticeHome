using Risk.Api.Domain;
using StructureMap.Configuration.DSL;

namespace Risk.Api.Adpaters
{
    public class RealAdapters : Registry
    {
        public RealAdapters()
        {
            For<MongoConfiguration>();
            For<IRiskStore>().Use<RiskStore>();
        }
    }

    public class InMemoryAdapters : Registry
    {
        
    }
}
