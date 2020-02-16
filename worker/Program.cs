using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace worker {
  internal class Program {
    public static async Task PostMessage(string postData) {
      var json = JsonConvert.SerializeObject(postData);
      var content = new StringContent(json, Encoding.UTF8, "application/json");

      using var httpClientHandler = new HttpClientHandler {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
      };
      using var client = new HttpClient(httpClientHandler);
      var result = await client.PostAsync("https://publisher_api:443/api/values", content);
      var resultContent = await result.Content.ReadAsStringAsync();
      Console.WriteLine($"Server returned: {resultContent}");
    }

    static void Main() {
      Console.WriteLine("Posting a message!");
      PostMessage("Test Message").Wait();
    }
  }
}
