using CipherGate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CipherGate.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; private set; }
    public DbSet<SshServer> SshServers { get; private set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>(users =>
        {
            users.ToTable("users");
            
            users.HasIndex(x => x.Email)
                .IsUnique();
            
            users.Property(x => x.Id)
                .HasColumnName("id");
            
            users.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(150);
            
            users.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(255);
            
            users.Property(x => x.PasswordHash)
                .HasColumnName("password_hash")
                .HasMaxLength(255);
            
            users.Property(x => x.Role)
                .HasColumnName("role")
                .HasConversion<string>();
            
            users.Property(x => x.CreatedAt)
                .HasColumnName("created_at");
            
            users.Property(x => x.ModifiedAt)
                .HasColumnName("modified_at");
            
            users.Navigation(x => x.Servers)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
            
            users.HasMany(x => x.Servers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        });

        mb.Entity<SshServer>(servers =>
        {
            servers.ToTable("ssh_servers");

            servers.Property(x => x.Id)
                .HasColumnName("id");
            
            servers.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasMaxLength(255);
            
            servers.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(255);
    
            servers.Property(x => x.Host)
                .HasColumnName("host")
                .HasMaxLength(255);
            
            servers.Property(x => x.Port)
                .HasColumnName("port");
            
            servers.Property(x => x.Username)
                .HasColumnName("username")
                .HasMaxLength(255);
            
            servers.Property(x => x.PrivateKey)
                .HasColumnName("private_key")
                .HasMaxLength(512);
            
            servers.Property(x => x.CreatedAt)
                .HasColumnName("created_at");
            
            servers.Property(x => x.ModifiedAt)
                .HasColumnName("modified_at");
            
            servers.HasOne(x => x.User)
                .WithMany(x => x.Servers)
                .HasForeignKey(x => x.UserId);
        });
    }
}
