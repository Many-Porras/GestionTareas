namespace GestionTareas.Application.Dtos
{
    public class CreateTareaRequest
    {
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int CategoriaId { get; set; }
    }
}
    