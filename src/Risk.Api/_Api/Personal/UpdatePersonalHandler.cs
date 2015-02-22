using System.Linq;
using FluentValidation.Results;
using Pipeline;

namespace Risk.Api._Api.Personal
{
    public class UpdatePersonalHandler : AbstractCommandHandler<UpdatePersonal>
    {
        private readonly ValidatorProvider _validatorProvider;

        public UpdatePersonalHandler(ValidatorProvider validatorProvider)
        {
            _validatorProvider = validatorProvider;
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
        }
    }
}