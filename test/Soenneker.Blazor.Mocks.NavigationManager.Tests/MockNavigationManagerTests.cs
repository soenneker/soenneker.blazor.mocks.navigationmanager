using Soenneker.Tests.HostedUnit;
using Microsoft.AspNetCore.Components.Routing;
using System.Threading.Tasks;

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
    public async Task Default()
    {
        await Assert.That(_util.BaseUri).IsEqualTo("http://localhost/");
        await Assert.That(_util.Uri).IsEqualTo("http://localhost/");
    }

    [Test]
    public async Task NavigateTo_ResolvesRelativeUri_AndRaisesLocationChanged()
    {
        LocationChangedEventArgs? observed = null;
        _util.LocationChanged += (_, args) => observed = args;

        _util.NavigateTo("orders/42?tab=items#summary");

        await Assert.That(_util.Uri).IsEqualTo("http://localhost/orders/42?tab=items#summary");
        await Assert.That(observed).IsNotNull();
        await Assert.That(observed!.Location).IsEqualTo(_util.Uri);
        await Assert.That(observed.IsNavigationIntercepted).IsFalse();
    }
}
