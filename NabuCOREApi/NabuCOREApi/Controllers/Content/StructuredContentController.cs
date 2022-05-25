using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Content
{
    [Route("Content/StructuredContent")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Content")]
    public class StructuredContentController : ControllerBase
    {
        // GET: api/<StructuredContentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StructuredContentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StructuredContentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StructuredContentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StructuredContentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
