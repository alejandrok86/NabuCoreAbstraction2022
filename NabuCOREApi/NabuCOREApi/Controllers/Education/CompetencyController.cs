using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Education
{
    [Route("Education/Competency")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]

    public class CompetencyController : ControllerBase
    {
        // GET: api/<CompetencyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CompetencyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompetencyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompetencyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompetencyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
