using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Worker.Services {
  public class RabbitConsumerService: IConsumerService {
    private readonly IModel _channel;

    public RabbitConsumerService() {
      var factory = new ConnectionFactory { HostName = "rabbitmq", Port = 5672, UserName = "guest", Password = "guest" };
      var conn = factory.CreateConnection();
      this._channel = conn.CreateModel();

      _channel.QueueDeclare(queue: "hello",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);
    }

    public void EventConsumer() {
      var consumer = new EventingBasicConsumer(_channel);

      consumer.Received += (model, ea) => {
        var body = ea.Body;
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Received from Rabbit: {message}");
      };
      _channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
    }
  }
}
