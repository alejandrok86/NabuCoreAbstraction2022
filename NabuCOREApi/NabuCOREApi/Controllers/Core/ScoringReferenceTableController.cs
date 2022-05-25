using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Core
{
    [Route("Core/ScoringReferenceTable")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Core")]
    public class ScoringReferenceTableController : ControllerBase
    {
        // GET: api/<ScoringReferenceTableController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ScoringReferenceTableController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ScoringReferenceTableController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ScoringReferenceTableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScoringReferenceTableController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
