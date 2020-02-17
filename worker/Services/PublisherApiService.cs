using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Services {
  internal class PublisherApiService: IPublisherApiService {

    public async Task PostMessage(string postData) {
      var json = JsonConvert.SerializeObject(postData);
      var content = new StringContent(json, Encoding.UTF8, "application/json");

      using var httpClientHandler = new HttpClientHandler {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
      };
      using var client = new HttpClient(httpClientHandler);
      var result = await client.PostAsync("http://publisher_api:80/api/values", content);
      var resultContent = await result.Content.ReadAsStringAsync();
      Console.WriteLine($"Server returned: {resultContent}");
    }
  }
}
