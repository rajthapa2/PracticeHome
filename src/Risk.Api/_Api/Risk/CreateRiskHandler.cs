using System;
using Pipeline;

namespace Risk.Api._Api.Risk
{
    public class CreateRiskHandler : AbstractCommandHandler<CreateRisk>
    {
        public override void HandleCommand(CreateRisk command)
        {
           Console.WriteLine("dkjalkre"); 
        }
    }
}
