using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Soenneker.Blazor.Mocks.NavigationManager.Registrars;

/// <summary>
/// A simple threadsafe version of NavigationManager for testing with Blazor
/// </summary>
public static class MockNavigationManagerRegistrar
{
    /// <summary>
    /// Registers a mock implementation of the NavigationManager as a singleton service in the specified
    /// IServiceCollection.
    /// </summary>
    /// <remarks>This method is useful for testing scenarios where a mock NavigationManager is needed to
    /// simulate navigation behavior without relying on the actual implementation.</remarks>
    /// <param name="services">The IServiceCollection to which the mock NavigationManager will be added.</param>
    /// <returns>The updated IServiceCollection instance to allow for method chaining.</returns>
    public static IServiceCollection AddMockNavigationManagerAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<Microsoft.AspNetCore.Components.NavigationManager, MockNavigationManager>();

        return services;
    }

    /// <summary>
    /// Registers a mock implementation of the NavigationManager as a scoped service in the specified service
    /// collection.
    /// </summary>
    /// <remarks>Use this method in test scenarios to replace the default NavigationManager with a mock
    /// implementation, allowing navigation-related behavior to be simulated without requiring a real Blazor
    /// environment.</remarks>
    /// <param name="services">The IServiceCollection to which the mock NavigationManager will be added. Cannot be null.</param>
    /// <returns>The IServiceCollection instance with the mock NavigationManager registered, enabling method chaining.</returns>
    public static IServiceCollection AddMockNavigationManagerAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<Microsoft.AspNetCore.Components.NavigationManager, MockNavigationManager>();

        return services;
    }
}
