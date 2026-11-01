namespace GestionTareas.Domain.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; } = "PENDIENTE";
        public int CategoriaId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
