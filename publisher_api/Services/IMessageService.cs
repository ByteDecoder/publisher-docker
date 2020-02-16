
namespace publisher_api.Services
{
  public interface IMessageService
  {
    bool Enqueue(string message);
  }
}