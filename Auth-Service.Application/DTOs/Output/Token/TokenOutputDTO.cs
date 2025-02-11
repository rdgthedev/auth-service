namespace Auth_Service.Application.DTOs.Output.Token;

public class TokenOutputDTO
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;

    public static TokenOutputDTO GenerateResult(
        string accessToken,
        string refreshToken)
    {
        return new TokenOutputDTO
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}