using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Financial
{
    [Route("Financial/AccountFee")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Financial")]

    public class AccountFeeController : ControllerBase
    {
        // GET: api/<AccountFeeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountFeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountFeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountFeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountFeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
