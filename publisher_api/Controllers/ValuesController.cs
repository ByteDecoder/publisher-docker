
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace publisher_api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ValuesController : ControllerBase
  {

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    [HttpPost]
    public IActionResult Post([FromBody] string payload)
    {
      return Ok("{\"success\": \"true\"}");
    }
  }
}