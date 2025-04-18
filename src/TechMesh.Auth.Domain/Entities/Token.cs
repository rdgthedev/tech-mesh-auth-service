using TechMesh.Auth.Domain.Common;
using TechMesh.Auth.Domain.Enums;

namespace TechMesh.Auth.Domain.Entities;

public class Token : BaseEntity
{
    public string Value { get; private set; }
    public DateTime ExpirationTimeInMinutes { get; private set; }
    public bool IsRevoked { get; private set; }
    public ETokenType Type { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public Token(string value, Guid userId)
    {
        Value = value;
        UserId = userId;
    }

    private bool IsValid() => DateTime.Now < ExpirationTimeInMinutes || !IsRevoked;

    public void Revoke() => IsRevoked = true;
}