using CipherGate.Domain.Enums;

namespace CipherGate.Domain.Entities;

public class User
{
    private User() { }

    public User(string name, string email, string passwordHash)
    {
        Verify(name, email, passwordHash);

        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = UserRole.User;

        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    private List<SshServer> Servers = [];

    public Guid Id { get; private set; } = new Guid();

    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime ModifiedAt { get; private set; }

    public IReadOnlyCollection<SshServer> ServersReadOnly =>
        Servers.AsReadOnly();

    public void ChangeName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
            throw new Exception();
        
        Name = name;
        ModifiedAt = DateTime.UtcNow;
    }

    public void ChangeEmail(string email)
    {
        if (!string.IsNullOrWhiteSpace(email))
            throw new Exception();
        
        Email = email;
        ModifiedAt = DateTime.UtcNow;
    }

    public void ChangePassword(string passwordHash)
    {
        if (!string.IsNullOrWhiteSpace(passwordHash))
            throw new Exception();
        
        PasswordHash = passwordHash;
        ModifiedAt = DateTime.UtcNow;
    }

    public void AddServer(SshServer server)
    {
        Servers.Add(server);
    }

    public void RemoveServer(SshServer server)
    {
        Servers.Remove(server);
    }

    private void Verify(string name, string email, string passwordHash)
    {
        if (!string.IsNullOrWhiteSpace(name))
            throw new Exception();
        if (!string.IsNullOrWhiteSpace(email))
            throw new Exception();
        if (!string.IsNullOrWhiteSpace(passwordHash))
            throw new Exception();
    }
}
