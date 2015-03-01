using System;
using MongoDB.Bson.Serialization.Attributes;
using Risk.Api._Api.Personal;

namespace Risk.Api.Domain
{
    public class Risk
    {
        [BsonId]
        public Guid RiskId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public UpdatePersonal Personal { get; set; }
    }
}
