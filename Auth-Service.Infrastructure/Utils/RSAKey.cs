namespace Auth_Service.Infrastructure.Utils;

public static class RSAKey
{
    public static RSA Load(string privateKey)
    {
        var rsa = RSA.Create();
        rsa.ImportFromPem(privateKey);

        return rsa;
    }
}