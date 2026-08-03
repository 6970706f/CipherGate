namespace CipherGate.Application.Contracts.Responses;

public class SshServerResponse
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }

    public required string Name { get; init; }
    public required string Host { get; init; }
    public int Port { get; init; }
    public required string Username { get; init; }
    public string? PrivateKey { get; init; }
}
