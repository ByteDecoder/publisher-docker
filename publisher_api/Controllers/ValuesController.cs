
using Microsoft.AspNetCore.Mvc;
using PublisherApi.Services;
using System;

namespace PublisherApi.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class ValuesController: ControllerBase {
    private readonly IMessageService _messageService;

    public ValuesController(IMessageService messageService) => this._messageService = messageService;

    // POST api/values
    [HttpPost]
    public IActionResult Post(string payload) {
      Console.WriteLine($"Received a Post: {payload}");
      _messageService.Enqueue(payload);
      return Ok(new { Success = true });
    }
  }
}
