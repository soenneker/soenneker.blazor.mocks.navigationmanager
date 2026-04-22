using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.Mocks.NavigationManager.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class MockNavigationManagerTests : HostedUnitTest
{
    private readonly Microsoft.AspNetCore.Components.NavigationManager _util;

    public MockNavigationManagerTests(Host host) : base(host)
    {
        _util = Resolve<Microsoft.AspNetCore.Components.NavigationManager>(true);
    }

    [Test]
    public void Default()
    {

    }
}
