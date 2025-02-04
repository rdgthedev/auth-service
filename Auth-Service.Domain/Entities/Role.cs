using Auth_Service.Domain.Base;

namespace Auth_Service.Domain.Entities;

public class Role : Entity
{
    public string Name { get; set; }

    public Role(string name)
    {
        Name = name;
    }

    public static implicit operator string(Role role) => role.Name;
}