using System.Linq;
using FluentValidation;
using TheBestCloth.BLL.DTOs;

namespace TheBestCloth.API.Validators
{
    public class RegisterUserDtoValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(e => e.Email).EmailAddress();
            RuleFor(e => e.FirstName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.Password).NotEmpty()
                .MinimumLength(6)
                .Must(password => password.Any(char.IsDigit))
                .Must(password => password.Any(char.IsUpper));
        }
    }
}
