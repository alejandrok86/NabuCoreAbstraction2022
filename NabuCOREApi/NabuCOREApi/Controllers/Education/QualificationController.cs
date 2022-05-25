using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Education
{
    [Route("Education/Qualification")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]

    public class QualificationController : ControllerBase
    {
        // GET: api/<QualificationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<QualificationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QualificationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QualificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QualificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
