namespace Auth_Service.Infrastructure.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHashService _passwordHashService;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUnitOfWork unitOfWork,
        IPasswordHashService passwordHashService,
        ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _passwordHashService = passwordHashService;
        _tokenService = tokenService;
    }

    public async Task LogoutAsync(string refreshToken, CancellationToken cancellationToken)
    {
        var token = await _unitOfWork.RefreshTokens.GetByRefreshTokenValue(refreshToken, cancellationToken);

        if (token is null)
            throw new Exception("Ocorreu um erro. Não foi possível encontrar o refresh token na base de dados!");

        token.Revoke();

        await _unitOfWork.RefreshTokens.DeleteAsync(token, cancellationToken);
        await _unitOfWork.CommitAsync();
    }

    public async Task<TokenOutputDTO> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByEmail(email, cancellationToken);

        if (user is null)
            throw new Exception();

        var isValid = _passwordHashService.Verify(password, user.Password);

        if (!isValid)
            throw new Exception();

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        return TokenOutputDTO.GenerateResult(accessToken, refreshToken);
    }
}