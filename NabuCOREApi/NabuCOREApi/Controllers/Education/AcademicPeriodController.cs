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
    [Route("Education/AcademicPeriod")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]

    public class AcademicPeriodController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AcademicPeriod API", 1, 0, 0, "");

        public AcademicPeriodController(IConfiguration config)
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


        //public AcademicPeriod GetAcademicPeriod(int pAcademicPeriodID)
        [HttpGet("Get/{pAcademicPeriodID}")]
        public IActionResult Get(int pAcademicPeriodID)
        {
            Entities.Education.AcademicPeriod academicPeriod = new Entities.Education.AcademicPeriod();
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

                    return Ok(educationAbstraction.GetAcademicPeriod(pAcademicPeriodID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicPeriod.ErrorsDetected = true;
                    academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicPeriod);
                }
            }
            else
            {
                academicPeriod.ErrorsDetected = true;
                academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicPeriod);
            }
        }

        //public AcademicPeriod[] ListAcademicPeriods(int pEducationProviderID)
        [HttpGet("List/{pLanguageID}")]
        public IActionResult List(int pEducationProviderID)
        {

            Entities.Education.AcademicPeriod academicPeriod = new Entities.Education.AcademicPeriod();
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

                    return Ok(educationAbstraction.ListAcademicPeriods(pEducationProviderID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicPeriod.ErrorsDetected = true;
                    academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicPeriod);

                }
            }
            else
            {

                academicPeriod.ErrorsDetected = true;
                academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicPeriod);
            }
        }


        //public AcademicPeriod InsertAcademicPeriod(AcademicPeriod pAcademicPeriod, int pEducationProviderID)
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Education.AcademicPeriod pAcademicPeriod, int pEducationProviderID)
        {
            Entities.Education.AcademicPeriod academicPeriod = new Entities.Education.AcademicPeriod();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicPerioddTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicPerioddTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.InsertAcademicPeriod(pAcademicPeriod, pEducationProviderID));
                    }
                    else
                    {

                        academicPeriod.ErrorsDetected = true;
                        academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicPeriod);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicPeriod.ErrorsDetected = true;
                    academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicPeriod);
                }
            }
            else
            {

                academicPeriod.ErrorsDetected = true;
                academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicPerioddTo within Header"));
                return Unauthorized(academicPeriod);
            }
        }





        //public AcademicPeriod UpdateAcademicPeriod(AcademicPeriod pAcademicPeriod)
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Education.AcademicPeriod pAcademicPeriod)
        {
            Entities.Education.AcademicPeriod academicPeriod = new Entities.Education.AcademicPeriod();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicPerioddTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicPerioddTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.UpdateAcademicPeriod(pAcademicPeriod));
                    }
                    else
                    {

                        academicPeriod.ErrorsDetected = true;
                        academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicPeriod);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicPeriod.ErrorsDetected = true;
                    academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicPeriod);
                }
            }
            else
            {

                academicPeriod.ErrorsDetected = true;
                academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicPerioddTo within Header"));
                return Unauthorized(academicPeriod);
            }
        }




        //public AcademicPeriod DeleteAcademicPeriod(AcademicPeriod pAcademicPeriod)

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Education.AcademicPeriod pAcademicPeriod)
        {
            Entities.Education.AcademicPeriod academicPeriod = new Entities.Education.AcademicPeriod();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicPerioddTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicPerioddTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.DeleteAcademicPeriod(pAcademicPeriod));
                    }
                    else
                    {

                        academicPeriod.ErrorsDetected = true;
                        academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicPeriod);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicPeriod.ErrorsDetected = true;
                    academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicPeriod);
                }
            }
            else
            {

                academicPeriod.ErrorsDetected = true;
                academicPeriod.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicPerioddTo within Header"));
                return Unauthorized(academicPeriod);

            }
        }



        /*
         * 
        // GET: api/<AcademicPeriodController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AcademicPeriodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AcademicPeriodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AcademicPeriodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcademicPeriodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */


    }
}
