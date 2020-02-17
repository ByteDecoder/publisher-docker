using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Worker {
  public static class EngineStartup {
    private static readonly ContainerBuilder Container;

    static EngineStartup() => Container = new ContainerBuilder();

    public static IServiceProvider Services { get; private set; }

    public static void RegisterServices(Action<ContainerBuilder> configure) {
      var collection = new ServiceCollection();

      configure?.Invoke(Container);

      Container.Populate(collection);
      var appContainer = Container.Build();
      Services = new AutofacServiceProvider(appContainer);
    }

    public static void DisposeServices() {
      if(Services == null) return;
      if(Services is IDisposable service) service.Dispose();
    }
  }
}
