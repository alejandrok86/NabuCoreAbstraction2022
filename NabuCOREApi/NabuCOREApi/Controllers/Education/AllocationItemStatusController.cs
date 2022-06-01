using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.API.Helper;
using Microsoft.Extensions.Configuration;
using Octavo.Gate.Nabu.CORE.Abstraction;
using Octavo.Gate.Nabu.CORE.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Education
{
    [Route("Education/AllocationItemStatus")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]

    public class AllocationItemStatusController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AllocationItemStatus API", 1, 0, 0, "");

        public AllocationItemStatusController(IConfiguration config)
        {
            _config = config;
        }

        /************************************************************************************************************************************
     * API Version
     ***********************************************************************************************************************************/
        // GET Location/Version
        [HttpGet("Version")]
        public IActionResult GetVersion()
        {
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    return Ok(release);
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    release = new BaseVersion();
                    release.ErrorsDetected = true;
                    release.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(release);
                }
            }
            else
            {
                release = new BaseVersion();
                release.ErrorsDetected = true;
                release.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(release);
            }
        }


        //public AllocationItemStatus GetAllocationItemStatus(int pAllocationItemStatusID, int pLanguageID)
        [HttpGet("Get/{pAllocationItemStatusID}/{pLanguageID}")]
        public IActionResult Get(int pAllocationItemStatusID, int pLanguageID)
        {
            Entities.Education.AllocationItemStatus allocationItemStatus = new Entities.Education.AllocationItemStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                System.Reflection.MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                    return Ok(educationAbstraction.GetAllocationItemStatus(pAllocationItemStatusID,pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    allocationItemStatus.ErrorsDetected = true;
                    allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(allocationItemStatus);
                }
            }
            else
            {
                allocationItemStatus.ErrorsDetected = true;
                allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(allocationItemStatus);
            }
        }


        //public AllocationItemStatus[] ListAllocationItemStatus(int pLanguageID)
        [HttpGet("List/{pLanguageID}")]
        public IActionResult List(int pLanguageID)
        {

            Entities.Education.AllocationItemStatus allocationItemStatus = new Entities.Education.AllocationItemStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                    return Ok(educationAbstraction.ListAllocationItemStatus(pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    allocationItemStatus.ErrorsDetected = true;
                    allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(allocationItemStatus);

                }
            }
            else
            {

                allocationItemStatus.ErrorsDetected = true;
                allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(allocationItemStatus);
            }
        }





        //public AllocationItemStatus InsertAllocationItemStatus(AllocationItemStatus pAllocationItemStatus)
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Education.AllocationItemStatus pAllocationItemStatus)
        {
            Entities.Education.AllocationItemStatus allocationItemStatus = new Entities.Education.AllocationItemStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAllocationItemStatusdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAllocationItemStatusdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.InsertAllocationItemStatus(pAllocationItemStatus));
                    }
                    else
                    {

                        allocationItemStatus.ErrorsDetected = true;
                        allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(allocationItemStatus);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    allocationItemStatus.ErrorsDetected = true;
                    allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(allocationItemStatus);
                }
            }
            else
            {

                allocationItemStatus.ErrorsDetected = true;
                allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAllocationItemStatusdTo within Header"));
                return Unauthorized(allocationItemStatus);
            }
        }




        //public AllocationItemStatus UpdateAllocationItemStatus(AllocationItemStatus pAllocationItemStatus)
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Education.AllocationItemStatus pAllocationItemStatus)
        {
            Entities.Education.AllocationItemStatus allocationItemStatus = new Entities.Education.AllocationItemStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAllocationItemStatusdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAllocationItemStatusdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.UpdateAllocationItemStatus(pAllocationItemStatus));
                    }
                    else
                    {

                        allocationItemStatus.ErrorsDetected = true;
                        allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(allocationItemStatus);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    allocationItemStatus.ErrorsDetected = true;
                    allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(allocationItemStatus);
                }
            }
            else
            {

                allocationItemStatus.ErrorsDetected = true;
                allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAllocationItemStatusdTo within Header"));
                return Unauthorized(allocationItemStatus);
            }
        }


        //public AllocationItemStatus DeleteAllocationItemStatus(AllocationItemStatus pAllocationItemStatus)
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Education.AllocationItemStatus pAllocationItemStatus)
        {
            Entities.Education.AllocationItemStatus allocationItemStatus = new Entities.Education.AllocationItemStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAllocationItemStatusdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAllocationItemStatusdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.DeleteAllocationItemStatus(pAllocationItemStatus));
                    }
                    else
                    {

                        allocationItemStatus.ErrorsDetected = true;
                        allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(allocationItemStatus);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    allocationItemStatus.ErrorsDetected = true;
                    allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(allocationItemStatus);
                }
            }
            else
            {

                allocationItemStatus.ErrorsDetected = true;
                allocationItemStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAllocationItemStatusdTo within Header"));
                return Unauthorized(allocationItemStatus);

            }
        }





        /*
        // GET: api/<AllocationItemStatusController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AllocationItemStatusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AllocationItemStatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AllocationItemStatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AllocationItemStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        */

    }
}
