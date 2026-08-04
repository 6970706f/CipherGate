using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;
using CipherGate.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CipherGate.API.Controllers;

[Route("me")]
[ApiController]
public class MeController(
    IMeService meService
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeResponse>>> Get()
    {
        var users = await meService.GetAsync();

        return Ok(users);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<MeResponse>> GetById(Guid id)
    {
        var user = await meService.GetByIdAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<MeResponse>> Create(MeCreateRequest request)
    {
        var user = await meService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = user.Id },
            user
        );
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await meService.DeleteAsync(id);

        return NoContent();
    }

    [HttpPatch("{id:Guid}")]
    public async Task<ActionResult<MeResponse>> Update(Guid id, MeUpdateRequest request)
    {
        var user = await meService.UpdateAsync(id, request);

        return Ok(user);
    }
}
