using Microsoft.EntityFrameworkCore;
using TechMesh.Auth.Application.Contracts.Services;
using TechMesh.Auth.Application.Services;
using TechMesh.Auth.Domain.Contracts.Repositories;
using TechMesh.Auth.Domain.Contracts.UnitOfWork;
using TechMesh.Auth.Infrastructure.Database;
using TechMesh.Auth.Infrastructure.Persistence.Repositories;
using TechMesh.Auth.Infrastructure.Persistence.UnitOfWork;
using TechMesh.Auth.Infrastructure.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

#endregion

#region Transaction

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region Services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();