namespace GestionTareas.Application.Dtos
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; } = null!;
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
