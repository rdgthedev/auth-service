using Auth_Service.Domain.Interfaces.Repositories;
using Auth_Service.Infrastructure.Data.Context;
using Auth_Service.Infrastructure.Repositories;
using Auth_Service.Infrastructure.Services.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth_Service.Infrastructure.Extensions;

public static class Extensions
{
    public static IServiceCollection AddDbContextConfigurations(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AuthDbContext>(options => { options.UseNpgsql(connectionString); });
        return services;
    }

    public static IServiceCollection AddAuthService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }

    public static IServiceCollection AddTokenService(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        return services;
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}