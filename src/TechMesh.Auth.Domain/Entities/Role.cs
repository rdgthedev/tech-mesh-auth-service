using TechMesh.Auth.Domain.Common;
using TechMesh.Auth.Domain.Enums;

namespace TechMesh.Auth.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; private set; }
    public ERoleStatus Status { get; private set; }

    public Role(string name)
    {
        Name = name;
        Status = ERoleStatus.Active;
    }

    public void ChangeName(string name)
        => Name = name;
}