namespace Auth_Service.Infrastructure.Services.Authentication;

public class AuthService(
    IUnitOfWork unitOfWork,
    IPasswordHashService passwordHashService,
    ITokenService tokenService)
    : IAuthService
{
    public async Task LogoutAsync(string refreshToken, CancellationToken cancellationToken)
    {
        var token = await unitOfWork.RefreshTokens.GetByRefreshTokenValue(refreshToken, cancellationToken);

        if (token is null)
            throw new Exception("Ocorreu um erro. Não foi possível encontrar o refresh token na base de dados!");

        token.Revoke();

        await unitOfWork.RefreshTokens.DeleteAsync(token, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task<TokenOutputDTO> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByEmail(email, cancellationToken);

        if (user is null)
            throw new Exception();

        var isValid = passwordHashService.Verify(password, user.PasswordHash);

        if (!isValid)
            throw new Exception();

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();

        return TokenOutputDTO.GenerateResult(accessToken, refreshToken);
    }
}