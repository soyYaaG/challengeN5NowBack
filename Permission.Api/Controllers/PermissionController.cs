using MediatR;
using Microsoft.AspNetCore.Mvc;
using Permission.Domain.DTOs;
using Permission.Persistence.Commands;
using Permission.Persistence.Queries;

namespace Permission.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IMediator _mediator;

    public PermissionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllPermission")]
    public async Task<ActionResult<IEnumerable<PermisosDto>>> GetAll()
    {
        var all = await _mediator.Send(new GetAllPermissionQuery());

        if (all == null)
            return NotFound();

        return Ok(all);
    }

    [HttpPost(Name = "CreatePermission")]
    public async Task<ActionResult<PermisosDto>> Create(CreatePermissionCommand command)
    {
        var permission = await _mediator.Send(command);

        if (permission == null)
            return NotFound();

        return Ok(permission);
    }

    [HttpPut("{id}", Name = "UpdatePermission")]
    public async Task<ActionResult<PermisosDto>> Update(int id, UpdatePermissionCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        var permission = await _mediator.Send(command);

        if (permission == null)
            return NotFound();

        return Ok(permission);
    }
}