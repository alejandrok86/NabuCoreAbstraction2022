using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.CMS
{
    [Route("CMS/JavaScript")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "CMS")]
    public class JavaScriptController : ControllerBase
    {
        // GET: api/<JavaScriptController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JavaScriptController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JavaScriptController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JavaScriptController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JavaScriptController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
