using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Development
{
    [Route("Development/DefectPriority")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Development")]
    public class DefectPriorityController : ControllerBase
    {
        // GET: api/<DefectPriorityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DefectPriorityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DefectPriorityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DefectPriorityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DefectPriorityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
