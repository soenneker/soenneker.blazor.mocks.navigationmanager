namespace Soenneker.Blazor.Mocks.NavigationManager;

/// <summary>
/// Provides a mock implementation of the NavigationManager for use in unit testing Blazor components that depend on
/// navigation functionality.
/// </summary>
/// <remarks>This class simulates navigation behavior without performing actual browser navigation, allowing
/// components to be tested in isolation from the Blazor runtime environment. It is intended for use in test scenarios
/// where a real NavigationManager is not available or not desirable.</remarks>
public class MockNavigationManager: Microsoft.AspNetCore.Components.NavigationManager
{
    public MockNavigationManager()
    {
        Initialize("http://localhost/", "http://localhost/");
    }

    protected override void NavigateToCore(string uri, bool forceLoad)
    {
        Uri = uri;
    }
}
