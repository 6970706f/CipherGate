using CipherGate.Application.Contracts.Requests;
using CipherGate.Application.Contracts.Responses;
using CipherGate.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CipherGate.API.Controllers;

[ApiController]
[Route("users")]
public class UserController(
    IUserService userService
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> Get()
    {
        var users = await userService.GetAsync();

        return Ok(users);
    }

    [HttpGet("{Id:Guid}")]
    public async Task<ActionResult<UserResponse>> GetById(Guid id)
    {
        var user = await userService.GetByIdAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserCreateRequest request)
    {
        var user = await userService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { Id = user.Id },
            user
        );
    }

    [HttpDelete("{Id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await userService.DeleteAsync(id);

        return NoContent();
    }

    [HttpPatch("{id:Guid}")]
    public async Task<ActionResult<UserResponse>> Update(Guid id, [FromBody] UserUpdateRequest request)
    {
        var user = await userService.UpdateAsync(id, request);

        return Ok(user);
    }
}
