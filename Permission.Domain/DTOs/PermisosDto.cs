namespace Permission.Domain.DTOs;

public class PermisosDto
{
    public int Id { get; set; }
    public required string NombreEmpleado { get; set; }
    public required string ApellidoEmpleado { get; set; }
    public DateTime FechaPermiso { get; set; }
    public required TipoPermisosDto TipoPermisos {get; set; }
}