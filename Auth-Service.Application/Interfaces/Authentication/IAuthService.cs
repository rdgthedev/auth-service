using Auth_Service.Application.DTOs.Output.Token;

namespace Auth_Service.Application.Interfaces.Authentication;

public interface IAuthService
{
    Task LogoutAsync(string refreshToken, CancellationToken cancellationToken);

    Task<TokenOutputDTO> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken);
}