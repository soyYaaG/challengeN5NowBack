using MediatR;
using Permission.Domain.DTOs;

namespace Permission.Persistence.Queries;

public record GetAllPermissionTypesQuery : IRequest<IEnumerable<TipoPermisosDto>>;