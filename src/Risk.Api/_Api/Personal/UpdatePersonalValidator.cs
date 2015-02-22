using FluentValidation;

namespace Risk.Api._Api.Personal
{
    public class UpdatePersonalValidator : AbstractValidator<UpdatePersonal>
    {
        public UpdatePersonalValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
        }  
    }
}