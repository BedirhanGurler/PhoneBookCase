using FluentValidation;
using PhoneBookApi.Models.Concrete;
using PhoneBookApi.Models.DTO;

namespace PhoneBookApi.Core.ValidationRules
{
    public class PersonValidator: AbstractValidator<PersonDTO>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Email alanı asla boş kalamaz!")
                .EmailAddress();

            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number alanı asla boş kalamaz!")
                .MinimumLength(10)
                .MaximumLength(11);
        }
    }
}
