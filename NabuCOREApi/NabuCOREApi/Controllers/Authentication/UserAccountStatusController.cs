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

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Authentication
{
    [Route("Authentication/UserAccountStatus")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication")]
    public class UserAccountStatusController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("UserAccountStatus API", 1, 0, 0, "");

        public UserAccountStatusController(IConfiguration config)
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

        /*
        // GET: api/<UserAccountStatusController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAccountStatusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserAccountStatusController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserAccountStatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAccountStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */


        // public UserAccountStatus GetUserAccountStatus(int pUserAccountStatusID, int pLanguageID)


        [HttpGet("Get/{pUserAccountStatusID}/{pLanguageID}")]
        public IActionResult Get(int pUserAccountStatusID, int pLanguageID)
        {
            Entities.Authentication.UserAccountStatus userAccountStatus = new Entities.Authentication.UserAccountStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                System.Reflection.MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                    return Ok(authenticationAbstraction.GetUserAccountStatus(pUserAccountStatusID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountStatus.ErrorsDetected = true;
                    userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountStatus);
                }
            }
            else
            {
                userAccountStatus.ErrorsDetected = true;
                userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccountStatus);
            }
        }


        //public UserAccountStatus GetUserAccountStatusByAlias(string pAlias, int pLanguageID)
        [HttpGet("Get/{pAlias}/{pLanguageID}")]
        public IActionResult Get(string pAlias, int pLanguageID)
        {
            Entities.Authentication.UserAccountStatus userAccountStatus = new Entities.Authentication.UserAccountStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                System.Reflection.MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                    return Ok(authenticationAbstraction.GetUserAccountStatusByAlias(pAlias, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountStatus.ErrorsDetected = true;
                    userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountStatus);
                }
            }
            else
            {
                userAccountStatus.ErrorsDetected = true;
                userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccountStatus);
            }
        }


        //public UserAccountStatus[] ListUserAccountStatus(int pLanguageID)
        [HttpGet("List/{pLanguageID}")]
        public IActionResult List(int pLanguageID)
        {

            Entities.Authentication.UserAccountStatus userAccountStatus = new Entities.Authentication.UserAccountStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                    return Ok(authenticationAbstraction.ListUserAccountStatus(pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountStatus.ErrorsDetected = true;
                    userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountStatus);

                }
            }
            else
            {

                userAccountStatus.ErrorsDetected = true;
                userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccountStatus);
            }
        }


        // public UserAccountStatus InsertUserAccountStatus(UserAccountStatus pUserAccountStatus)

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Authentication.UserAccountStatus pUserAccountStatus)
        {
            Entities.Authentication.UserAccountStatus userAccountStatus = new Entities.Authentication.UserAccountStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountStatusdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountStatusdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.InsertUserAccountStatus(pUserAccountStatus));
                    }
                    else
                    {

                        userAccountStatus.ErrorsDetected = true;
                        userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountStatus);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountStatus.ErrorsDetected = true;
                    userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountStatus);
                }
            }
            else
            {

                userAccountStatus.ErrorsDetected = true;
                userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountStatusdTo within Header"));
                return Unauthorized(userAccountStatus);
            }
        }



        // public UserAccountStatus UpdateUserAccountStatus(UserAccountStatus pUserAccountStatus)
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Authentication.UserAccountStatus pUserAccountStatus)
        {
            Entities.Authentication.UserAccountStatus userAccountStatus = new Entities.Authentication.UserAccountStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountStatusdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountStatusdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.UpdateUserAccountStatus(pUserAccountStatus));
                    }
                    else
                    {

                        userAccountStatus.ErrorsDetected = true;
                        userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountStatus);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountStatus.ErrorsDetected = true;
                    userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountStatus);
                }
            }
            else
            {

                userAccountStatus.ErrorsDetected = true;
                userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountStatusdTo within Header"));
                return Unauthorized(userAccountStatus);
            }
        }


        // public UserAccountStatus DeleteUserAccountStatus(UserAccountStatus pUserAccountStatus)
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Authentication.UserAccountStatus pUserAccountStatus)
        {
            Entities.Authentication.UserAccountStatus userAccountStatus = new Entities.Authentication.UserAccountStatus();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountStatusdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountStatusdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.DeleteUserAccountStatus(pUserAccountStatus));
                    }
                    else
                    {

                        userAccountStatus.ErrorsDetected = true;
                        userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountStatus);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountStatus.ErrorsDetected = true;
                    userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountStatus);
                }
            }
            else
            {

                userAccountStatus.ErrorsDetected = true;
                userAccountStatus.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountStatusdTo within Header"));
                return Unauthorized(userAccountStatus);

            }
        }
    }
}
