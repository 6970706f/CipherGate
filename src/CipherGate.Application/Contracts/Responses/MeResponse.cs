using CipherGate.Domain.Enums;

namespace CipherGate.Application.Contracts.Responses;

public class MeResponse
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public UserRole Role { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ModifiedAt { get; init; }
}
