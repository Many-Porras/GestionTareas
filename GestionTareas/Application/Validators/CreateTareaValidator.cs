using GestionTareas.Application.Dtos;
using FluentValidation;

namespace GestionTareas.Application.Validators
{
    public class CreateTareaValidator : AbstractValidator<CreateTareaRequest>
    {
        public CreateTareaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .Length(3, 150).WithMessage("El título debe tener entre 3 y 150 caracteres.");

            RuleFor(x => x.FechaFin)
                .GreaterThanOrEqualTo(x => x.FechaInicio)
                .When(x => x.FechaFin.HasValue)
                .WithMessage("La fecha de fin debe ser mayor o igual a la fecha de inicio.");

            RuleFor(x => x.CategoriaId)
                .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");
        }
    }
}
