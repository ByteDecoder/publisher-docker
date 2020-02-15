
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace publisher_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ValuesController : ControllerBase
  {

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post(string payload)
    {
      return Ok(new { sucess = true });
    }
  }
}
