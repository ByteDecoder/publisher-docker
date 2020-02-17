using System.Threading.Tasks;

namespace Worker.Services {
  internal interface IPublisherApiService {
    Task PostMessage(string postData);
  }
}
