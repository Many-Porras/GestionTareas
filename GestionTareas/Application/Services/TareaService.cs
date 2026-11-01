using FluentValidation;
using GestionTareas.Application.Common;
using GestionTareas.Application.Dtos;
using GestionTareas.Application.Interfaces;

namespace GestionTareas.Application.Services
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _repository;
        private readonly IValidator<CreateTareaRequest> _validator;

        public TareaService(ITareaRepository repository, IValidator<CreateTareaRequest> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result<IEnumerable<TareaDto>>> ListarTareasAsync(int? categoriaId = null)
        {
            var tareas = await _repository.ListarAsync(categoriaId);
            return Result<IEnumerable<TareaDto>>.Success(tareas);
        }

        public async Task<Result<int>> CrearTareaAsync(CreateTareaRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result<int>.Failure(errors);
            }

            try
            {
                var idGenerado = await _repository.CrearAsync(request);
                return Result<int>.Success(idGenerado);
            }
            catch (Exception ex)
            {
                return Result<int>.Failure(ex.Message);
            }
        }
    }
}
