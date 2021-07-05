using FluentValidation;
using Template.Domain.DTOs.Request;

namespace Template.API.Validation
{
    public class LoginValidator : AbstractValidator<RequestLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(l => l.NombreUsuario)
                   .MinimumLength(0).WithMessage("El nombre de usuario no puede estar vacío");

            RuleFor(l => l.Contraseña)
                .MinimumLength(0).WithMessage("La contraseña no puede estar vacía");
        }
    }
}
