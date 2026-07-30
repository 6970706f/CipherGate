using CipherGate.Domain.Enums;

namespace CipherGate.Application.Contracts.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public UserRole Role { get; set; }
}
