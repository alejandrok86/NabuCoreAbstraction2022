using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Financial
{
    [Route("Financial/AccountDefinition")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Financial")]

    public class AccountDefinitionController : ControllerBase
    {
        // GET: api/<AccountDefinitionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountDefinitionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountDefinitionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountDefinitionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountDefinitionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
