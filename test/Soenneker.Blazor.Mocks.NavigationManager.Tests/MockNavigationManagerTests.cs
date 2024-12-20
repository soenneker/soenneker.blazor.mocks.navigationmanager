using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blazor.Mocks.NavigationManager.Tests;

[Collection("Collection")]
public class MockNavigationManagerTests : FixturedUnitTest
{
    private readonly Microsoft.AspNetCore.Components.NavigationManager _util;

    public MockNavigationManagerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<Microsoft.AspNetCore.Components.NavigationManager>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
