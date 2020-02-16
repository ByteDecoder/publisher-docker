
using System;
using System.Text;
using RabbitMQ.Client;

namespace publisher_api.Services {
  public class MessageService: IMessageService {
    private readonly IModel _channel;

    public MessageService() {
      Console.WriteLine("About to connect to RabbitMQ");

      var factory = new ConnectionFactory {
        HostName = "rabbitmq",
        Port = 5672,
        UserName = "guest",
        Password = "guest"
      };

      var connection = factory.CreateConnection();
      _channel = connection.CreateModel();
      _channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, null);
    }

    public bool Enqueue(string message) {
      var body = Encoding.UTF8.GetBytes($"Server processed: {message}");
      _channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
      Console.WriteLine(" [x] Published {0} to RabbitMQ", message);
      return true;
    }
  }
}