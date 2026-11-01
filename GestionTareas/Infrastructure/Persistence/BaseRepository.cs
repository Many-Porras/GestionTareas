using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GestionTareas.Infrastructure.Persistence;

public abstract class BaseRepository
{
    private readonly string _connectionString;

    protected BaseRepository(IConfiguration configuration)
    {
        // 1. Intentamos leer desde el appsettings de forma normal
        var connectionFromConfig = configuration.GetConnectionString("DefaultConnection");

        if (!string.IsNullOrEmpty(connectionFromConfig))
        {
            _connectionString = connectionFromConfig;
        }
        else
        {
            // 2. PLAN DE RESPALDO IMPENETRABLE: Si da null, le inyectamos la cadena requerida directamente
            _connectionString = "Server=localhost;Database=PE_WINET_CRM;User Id=sa;Password=Porr@s150787;TrustServerCertificate=True;";
        }
    }

    protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
