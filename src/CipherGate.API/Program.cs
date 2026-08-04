using CipherGate.Application.Interfaces.Repositories;
using CipherGate.Application.Interfaces.Services;
using CipherGate.Application.Services;
using CipherGate.Infrastructure.Contexts;
using CipherGate.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ISshServerService, SshServerService>();
builder.Services.AddScoped<ISshServerRepository, SshServerRepository>();

builder.Services.AddScoped<IMeService, MeService>();

string? connectionString = builder.Configuration["ConnectionString:DefaultConnection"]
    ?? throw new Exception("connections string error");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MariaDbServerVersion(new Version(11, 4))
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
