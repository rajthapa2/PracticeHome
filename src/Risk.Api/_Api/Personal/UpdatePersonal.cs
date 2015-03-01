using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Pipeline;

namespace Risk.Api._Api.Personal
{
    public class UpdatePersonal : ICommand
    {
        [BsonIgnore, JsonIgnore]
        public Guid RiskId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }  
    }
}