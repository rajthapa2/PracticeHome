using Pipeline;
using Risk.Api.Domain;

namespace Risk.Api._Api.Risk
{
    public class CreateRiskHandler : AbstractCommandHandler<CreateRisk>
    {
        private readonly IRiskStore _riskStore;

        public CreateRiskHandler(IRiskStore riskStore)
        {
            _riskStore = riskStore;
        }

        public override void HandleCommand(CreateRisk command)
        {
            var risk = new Domain.Risk
            {
                RiskId = command.RiskId
            };
            _riskStore.Save(risk);
        }
    }
}
