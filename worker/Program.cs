using Autofac;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UtilsLibrary;
using Worker.Services;

namespace Worker {
  public class Program {
    private const int WaitingTime = 10000;

    static void Main() {
      EngineStartup.RegisterServices(service => {
        service.RegisterType<PublisherApiService>().As<IPublisherApiService>().SingleInstance();
        service.RegisterType<RabbitConsumerService>().As<IConsumerService>().SingleInstance();
      });

      PostMessages();
      ConsumeMessages();

      EngineStartup.DisposeServices();
    }


    private static void PostMessages() {
      var service = EngineStartup.Services.GetService<IPublisherApiService>();
      var messages = new[] { "one", "two", "three", "four", "five" };

      Console.WriteLine("Sleeping to wait for RabbitMQ");
      Task.Delay(WaitingTime).Wait();

      Console.WriteLine("Posting a message!");
      5.Times(index => service.PostMessage(messages[index]).Wait());
      Task.Delay(WaitingTime).Wait();
    }

    private static void ConsumeMessages() {
      var service = EngineStartup.Services.GetService<IConsumerService>();

      Console.WriteLine(new string('-', 25));
      Console.WriteLine("Consuming Queue Now");
      Console.WriteLine(new string('-', 25));

      service.EventConsumer();
    }
  }
}
