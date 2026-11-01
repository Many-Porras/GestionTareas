using GestionTareas.Application.Common;
using GestionTareas.Application.Dtos;

namespace GestionTareas.Application.Interfaces
{
    public interface ITareaService
    {
        Task<Result<IEnumerable<TareaDto>>> ListarTareasAsync(int? categoriaId = null);
        Task<Result<int>> CrearTareaAsync(CreateTareaRequest request);
    }
}
