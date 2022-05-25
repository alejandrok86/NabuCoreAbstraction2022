using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Development
{
    [Route("Development/Defect")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Development")]
    public class DefectController : ControllerBase
    {
        // GET: api/<DefectController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DefectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DefectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DefectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DefectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
