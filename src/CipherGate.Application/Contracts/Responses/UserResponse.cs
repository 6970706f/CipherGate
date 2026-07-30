using CipherGate.Domain.Enums;

namespace CipherGate.Application.Contracts.Responses;

public class UserResponse
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public UserRole Role { get; init; }
}
