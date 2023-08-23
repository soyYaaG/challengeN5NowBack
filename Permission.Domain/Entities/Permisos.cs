namespace Permission.Domain.Entities;

public class Permisos
{
    public int Id { get; set; }
    public required string NombreEmpleado { get; set; }
    public required string ApellidoEmpleado { get; set; }
    public int TipoPermiso { get; set; }
    public DateTime FechaPermiso { get; set; } = DateTime.UtcNow;
    public TipoPermisos? TipoPermisos {get; set; }
}