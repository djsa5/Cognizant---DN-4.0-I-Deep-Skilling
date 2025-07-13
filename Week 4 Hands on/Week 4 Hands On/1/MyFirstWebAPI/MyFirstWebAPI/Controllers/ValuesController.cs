using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: /values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET: /values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"value {id}");
        }

        // POST: /values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Added: {value}");
        }

        // PUT: /values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Updated id {id} with value {value}");
        }

        // DELETE: /values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleted id {id}");
        }
    }
}
