using System.Linq;
using FluentValidation.Results;
using Pipeline;
using Risk.Api.Domain;

namespace Risk.Api._Api.Personal
{
    public class UpdatePersonalHandler : AbstractCommandHandler<UpdatePersonal>
    {
        private readonly ValidatorProvider _validatorProvider;
        private readonly IRiskStore _riskStore;

        public UpdatePersonalHandler(ValidatorProvider validatorProvider, 
            IRiskStore riskStore)
        {
            _validatorProvider = validatorProvider;
            _riskStore = riskStore;
        }

        public override void HandleCommand(UpdatePersonal command)
        {
            var validators = _validatorProvider.For<UpdatePersonal>();
            var result = new ValidationResult();
            foreach (var validator in validators)
            {
                validator.Validate(command)
                    .Errors.ToList()
                    .ForEach(e=> result.Errors.Add(e));
            }

            if (!result.IsValid)
            {
                throw new RangeValidationException(result.Errors);
            }
            else
            {
                _riskStore.Update(command);
            }
            

        }
    }
}