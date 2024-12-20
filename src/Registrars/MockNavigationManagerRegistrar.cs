using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Soenneker.Blazor.Mocks.NavigationManager.Registrars;

/// <summary>
/// A simple threadsafe version of NavigationManager for testing with Blazor
/// </summary>
public static class MockNavigationManagerRegistrar
{
    public static IServiceCollection AddMockNavigationManagerAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<Microsoft.AspNetCore.Components.NavigationManager, MockNavigationManager>();

        return services;
    }
}
