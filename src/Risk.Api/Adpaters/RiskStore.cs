using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Pipeline;
using Risk.Api.Domain;
using Risk.Api._Api.Personal;

namespace Risk.Api.Adpaters
{
    public class RiskStore : IRiskStore
    {
        private readonly MongoDatabase _mongoDatabase;

        public MongoCollection<Domain.Risk> Collection
        {
            get { return _mongoDatabase.GetCollection<Domain.Risk>("scratchPad"); }
        }

        public RiskStore(MongoConfiguration configuration)
        {
            var mongoServerConnectionString = configuration.BaseUrl;
            var mongoClient = new MongoClient(mongoServerConnectionString);
            var mongoServer = mongoClient.GetServer();
            _mongoDatabase = mongoServer.GetDatabase(configuration.Database);
        }

        public void Save(Domain.Risk risk)
        {
            risk.Updated = DateTimeOffset.Now;
            Collection.Save(risk);
        }

        public void Update(ICommand command)
        {
            var riskId = command.RiskId;
            var risk = Collection.Find(Query<Domain.Risk>.EQ(x => x.RiskId, riskId)).FirstOrDefault();

            if (risk != null)
            {
                risk.Personal = (UpdatePersonal) command;
                Collection.Save(risk);
            }
        }
    }
}
