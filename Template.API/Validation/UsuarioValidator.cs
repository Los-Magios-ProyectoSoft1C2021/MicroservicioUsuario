using FluentValidation;
using System.Text.RegularExpressions;
using Template.Domain.DTOs.Request;

namespace Template.API.Validation
{
    public class UsuarioValidator : AbstractValidator<RequestUsuarioDto>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Dni)
                .GreaterThan(0).WithMessage("El DNI ingresado no es válido")
                .NotNull().WithMessage("El DNI no puede estar vacío");

            RuleFor(u => u.Nombre)
                .NotEmpty().WithMessage("El nombre no puede estar vacío")
                .Must(x => Regex.IsMatch(x, @"(?i)^(?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ])+$")).WithMessage("El nombre sólo debe contener letras");

            RuleFor(u => u.Apellido)
                .NotEmpty().WithMessage("El apellido no puede estar vacío")
                .Must(x => Regex.IsMatch(x, @"(?i)^(?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ])+$")).WithMessage("El apellido sólo debe contener letras");

            RuleFor(u => u.NombreUsuario)
                .MinimumLength(6).WithMessage("El nombre de usuario debe tener 8 o más caracteres")
                .Must(x => Regex.IsMatch(x, @"^[a-zA-Z0-9]+$")).WithMessage("El ");

            RuleFor(u => u.Contraseña)
                .MinimumLength(8).WithMessage("El contraseña debe tener al menos 8 caracteres");

            RuleFor(u => u.Correo)
                .EmailAddress().WithMessage("No se ha ingresado un correo válido");

            RuleFor(u => u.Telefono)
                .Must(x => Regex.IsMatch(x, @"^[0-9- ]+$")).WithMessage("No se ha ingresado un teléfono válido");

            RuleFor(u => u.Nacionalidad)
                .Must(x => Regex.IsMatch(x, @"(?i)^(?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ])+$")).WithMessage("La nacionalidad sólo puede contener letras");
        }
    }
}
