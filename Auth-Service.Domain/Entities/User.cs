using Auth_Service.Domain.Base;

namespace Auth_Service.Domain.Entities;

public class User : Entity
{
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public List<int> _rolesIds { get; private set; }
    private IReadOnlyCollection<int> RolesIds => _rolesIds;
    public List<Role> Roles { get; set; }

    public User(
        string email,
        string passwordHash,
        int roleId)
    {
        Email = email;
        PasswordHash = passwordHash;
        AssignRole(roleId);
    }

    public void AssignRole(int roleId)
    {
        if (roleId <= 0)
            throw new Exception("O id do perfil do usuário deve maior do que zero!");

        _rolesIds.Add(roleId);
    }

    public void UnassignRole(int roleId)
    {
        if (roleId <= 0)
            throw new Exception("O id do perfil do usuário deve maior do que zero!");

        _rolesIds.Remove(roleId);
    }
}