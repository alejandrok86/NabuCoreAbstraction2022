using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.CMS
{
    [Route("CMS/PageView")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "CMS")]

    public class PageViewController : ControllerBase
    {
        // GET: api/<PageViewController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PageViewController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PageViewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PageViewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PageViewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
