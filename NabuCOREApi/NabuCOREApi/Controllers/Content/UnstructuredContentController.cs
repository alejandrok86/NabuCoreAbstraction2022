using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Content
{
    [Route("Content/UnstructuredContent")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Content")]
    public class UnstructuredContentController : ControllerBase
    {
        // GET: api/<UnstructuredContentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UnstructuredContentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UnstructuredContentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UnstructuredContentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnstructuredContentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
