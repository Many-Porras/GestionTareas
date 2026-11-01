using Dapper;
using GestionTareas.Application.Dtos;
using GestionTareas.Application.Interfaces;
using System.Data;

namespace GestionTareas.Infrastructure.Persistence
{
    public class TareaRepository : BaseRepository, ITareaRepository
    {
        public TareaRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<TareaDto>> ListarAsync(int? categoriaId = null)
        {
            using var connection = CreateConnection();
            var parametros = new { CategoriaId = categoriaId };

            return await connection.QueryAsync<TareaDto>(
                "dbo.usp_Tarea_Listar",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> CrearAsync(CreateTareaRequest request)
        {
            using var connection = CreateConnection();
            var parametros = new DynamicParameters();
            parametros.Add("@Titulo", request.Titulo, DbType.String);
            parametros.Add("@Descripcion", request.Descripcion, DbType.String);
            parametros.Add("@FechaInicio", request.FechaInicio, DbType.DateTime);
            parametros.Add("@FechaFin", request.FechaFin, DbType.DateTime);
            parametros.Add("@CategoriaId", request.CategoriaId, DbType.Int32);
            parametros.Add("@Estado", "PENDIENTE", DbType.String);

            return await connection.ExecuteScalarAsync<int>(
                "dbo.usp_Tarea_Crear",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
