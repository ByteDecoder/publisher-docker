
using Microsoft.AspNetCore.Mvc;
using publisher_api.Services;
using System;

namespace publisher_api.Controllers {
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
      return Ok(new { success = true });
    }
  }
}
