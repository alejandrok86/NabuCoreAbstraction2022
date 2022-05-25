using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Education
{
    [Route("Education/Tier")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]

    public class TierController : ControllerBase
    {
        // GET: api/<TierController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
