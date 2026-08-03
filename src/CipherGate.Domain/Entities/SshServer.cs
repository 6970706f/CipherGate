namespace CipherGate.Domain.Entities;

public class SshServer
{
    private SshServer() { }

    public SshServer(Guid userId, string name, string host, int port, string username, string? privateKey)
    {
        Verify(name, host, port, username);

        UserId = userId;

        Name = name;
        Host = host;
        Port = port;
        Username = username;
        PrivateKey = privateKey;

        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    
    public User User { get; private set; } = null!;

    public string Name { get; private set; } = null!;
    public string Host { get; private set; } = null!;
    public int Port { get; private set; }
    public string Username { get; private set; } = null!;
    public string? PrivateKey { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime ModifiedAt { get; private set; }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception();
        
        Name = name;
        ModifiedAt = DateTime.UtcNow;
    }

    public void ChangeHost(string host)
    {
        if (string.IsNullOrWhiteSpace(host))
            throw new Exception();
        
        Host = host;
        ModifiedAt = DateTime.UtcNow;
    }

    public void ChangePort(int port)
    {
        if (port < 0)
            throw new Exception();
        
        Port = port;
        ModifiedAt = DateTime.UtcNow;
    }

    public void ChangeUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new Exception();
        
        Username = username;
        ModifiedAt = DateTime.UtcNow;
    }

    public void ChangePrivateKey(string? privateKey)
    {
        PrivateKey = privateKey;
        ModifiedAt = DateTime.UtcNow;
    }

    private void Verify(string name, string host, int port, string username)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception();
        if (string.IsNullOrWhiteSpace(host))
            throw new Exception();
        if (string.IsNullOrWhiteSpace(username))
            throw new Exception();
        if (port <= 0)
            throw new Exception();
    }
}
