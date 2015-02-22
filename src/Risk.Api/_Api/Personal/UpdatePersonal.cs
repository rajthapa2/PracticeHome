using System;
using Newtonsoft.Json;
using Pipeline;

namespace Risk.Api._Api.Personal
{
    public class UpdatePersonal : ICommand
    {
        [JsonIgnore]
        public Guid RiskId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }  
    }
}