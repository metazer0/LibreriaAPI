namespace Libreria.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string? NombreLibro { get; set; }
        public bool Retirado { get; set; }
        public List<Autor>? Autores { get; set; }
    }
}
