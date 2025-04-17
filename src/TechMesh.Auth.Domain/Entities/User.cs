using TechMesh.Auth.Domain.Common;
using TechMesh.Auth.Domain.Enums;

namespace TechMesh.Auth.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public EUserStatus Status { get; private set; }
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; } = null!;

    public User(string email, string password)
    {
        Email = email;
        Password = password;
        Status = EUserStatus.Active;
    }

    public void UpdateEmail(string email)
        => Email = email;

    public void Activate()
        => Status = EUserStatus.Active;

    public void Deativate()
        => Status = EUserStatus.Inactive;

    public void ChangeRole(Guid roleId)
        => RoleId = roleId;
}