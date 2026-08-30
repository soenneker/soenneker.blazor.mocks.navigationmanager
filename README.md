[![](https://img.shields.io/nuget/v/soenneker.blazor.mocks.navigationmanager.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mocks.navigationmanager/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.mocks.navigationmanager/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.mocks.navigationmanager/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.mocks.navigationmanager.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mocks.navigationmanager/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.mocks.navigationmanager/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.mocks.navigationmanager/actions/workflows/codeql.yml)

# Soenneker.Blazor.Mocks.NavigationManager

A lightweight `NavigationManager` test double for code that needs URI resolution and `LocationChanged` notifications without a browser or Blazor renderer.

## Installation

```bash
dotnet add package Soenneker.Blazor.Mocks.NavigationManager
```

## Register it

Scoped registration is the safer default because the current URI is mutable:

```csharp
using Soenneker.Blazor.Mocks.NavigationManager.Registrars;

services.AddMockNavigationManagerAsScoped();
```

Resolve the normal framework abstraction from the test service provider:

```csharp
NavigationManager navigation =
    serviceProvider.GetRequiredService<NavigationManager>();
```

The registrar uses `TryAdd`, so it does not replace an existing `NavigationManager` registration. Register this mock before another implementation, or remove the existing descriptor in test setup when replacement is intended.

Singleton registration is also available:

```csharp
services.AddMockNavigationManagerAsSingleton();
```

A singleton shares navigation state across every scope that uses the service provider. Avoid it when tests run concurrently or expect isolated starting locations.

## Test navigation

The mock starts with both `BaseUri` and `Uri` set to `http://localhost/`.

```csharp
LocationChangedEventArgs? observed = null;
navigation.LocationChanged += (_, args) => observed = args;

navigation.NavigateTo("orders/42?tab=items#summary");

Assert.Equal(
    "http://localhost/orders/42?tab=items#summary",
    navigation.Uri);
Assert.Equal(navigation.Uri, observed?.Location);
Assert.False(observed?.IsNavigationIntercepted);
```

Relative routes are resolved against `BaseUri`; absolute URIs remain absolute. Each `NavigateTo` call updates `Uri` synchronously and raises `LocationChanged` with `IsNavigationIntercepted = false`.

## Deliberate limitations

This is a small stateful test double, not a browser simulator:

- `forceLoad`, history-entry replacement, and history state have no observable effect.
- It does not perform a page load, maintain back/forward history, intercept links, or model browser failures.
- It does not emulate navigation locks or asynchronous location-changing decisions.
- It is not synchronized for concurrent callers. Use a scoped instance per test and invoke it from one logical test flow.

For tests that need richer browser or renderer behavior, use a Blazor component-testing framework or browser automation instead.
