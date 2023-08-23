using MediatR;
using Permission.Domain.DTOs;
using Permission.Domain.Interfaces;
using Permission.Persistence.Queries;

namespace Permission.Application.Handlers;

public class GetAllPermissionTypesHandler : IRequestHandler<GetAllPermissionTypesQuery, IEnumerable<TipoPermisosDto>?>
{
    private readonly IGetallPermissionTypesRepository _repository;

    public GetAllPermissionTypesHandler(IGetallPermissionTypesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TipoPermisosDto>?> Handle(GetAllPermissionTypesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllPermissionTypesAsync();
    }
}