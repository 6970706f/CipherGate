using CipherGate.Domain.Enums;

namespace CipherGate.Application.Contracts.Requests;

public class UserCreateRequest
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}

public class UserUpdateRequest
{
    public required string Name { get; init; }
    public required string Password { get; init; }
    public required string Email { get; init; }
    public UserRole Role { get; init; }
}
