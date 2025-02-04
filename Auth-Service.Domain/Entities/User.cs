using Auth_Service.Domain.Base;

namespace Auth_Service.Domain.Entities;

public class User : Entity
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public int RoleId { get; set; }

    public User(
        string email,
        string password,
        int roleId)
    {
        Email = email;
        Password = password;
        RoleId = roleId;
    }
}