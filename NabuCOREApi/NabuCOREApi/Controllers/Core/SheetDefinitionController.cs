using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Core
{
    [Route("Core/SheetDefinition")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Core")]
    public class SheetDefinitionController : ControllerBase
    {
        // GET: api/<SheetDefinitionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SheetDefinitionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SheetDefinitionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SheetDefinitionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SheetDefinitionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
