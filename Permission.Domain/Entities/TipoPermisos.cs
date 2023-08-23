namespace Permission.Domain.Entities;

public class TipoPermisos
{
    public int Id { get; set; }
    public required string Descripcion { get; set; }
    public ICollection<Permisos>? Permisos { get; set; } = new List<Permisos>();
}