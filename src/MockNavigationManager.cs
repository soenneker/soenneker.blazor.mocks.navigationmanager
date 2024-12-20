namespace Soenneker.Blazor.Mocks.NavigationManager;

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
