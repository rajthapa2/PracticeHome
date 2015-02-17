using System;
using Pipeline;

namespace Risk.Api._Api.Risk
{
    public class CreateRisk : ICommand
    {
        public Guid RiskId { get; set; }
    }
}