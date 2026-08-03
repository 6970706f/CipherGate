namespace CipherGate.Application.Contracts.Requests;

public class SshServerCreateRequest
{
    public Guid UserId { get; init; }
    public required string Name { get; init; }
    public required string Host { get; init; }
    public int Port { get; init; }
    public required string Username { get; init; }
    public string? PrivateKey { get; init; }
}

public class SshServerUpdateRequest
{
    public required string Name { get; init; }
    public required string Host { get; init; }
    public int Port { get; init; }
    public required string Username { get; init; }
    public string? PrivateKey { get; init; }
}
