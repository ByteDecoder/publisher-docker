using Autofac;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UtilsLibrary;
using Worker.Services;

namespace Worker {
  internal class Program {
    private const int WaitingTime = 10000;

    static void Main() {
      Startup.RegisterServices(service => {
        service.RegisterType<IPublisherApiService>().As<PublisherApiService>().SingleInstance();
      });

      PostMessages();

      Console.WriteLine("Consuming Queue Now");

      Startup.DisposeServices();
    }


    private static void PostMessages() {
      var service = Startup.Services.GetService<IPublisherApiService>();
      var messages = new[] { "one", "two", "three", "four", "five" };

      Console.WriteLine("Sleeping to wait for RabbitMQ");
      Task.Delay(WaitingTime).Wait();
      Console.WriteLine("Posting a message!");
      5.Times(index => service.PostMessage(messages[index]).Wait());
      Task.Delay(WaitingTime).Wait();
    }
  }
}
