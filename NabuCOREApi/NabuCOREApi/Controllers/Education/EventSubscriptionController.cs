using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Education
{
    [Route("Education/EventSubscription")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]

    public class EventSubscriptionController : ControllerBase
    {
        // GET: api/<EventSubscriptionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EventSubscriptionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventSubscriptionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventSubscriptionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventSubscriptionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
