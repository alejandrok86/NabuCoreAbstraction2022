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
    [Route("Authentication/UserRole")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication")]
    public class UserRoleController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AuthenticationToken API", 1, 0, 0, "");

        public UserRoleController (IConfiguration config)
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

        // public UserRole GetUserRole(int pUserRoleID, int pLanguageID)

        //public UserRole[] ListUserRoles(int pUserAccountID, int pLanguageID)


        // public UserRole InsertUserRole(UserRole pUserRole, int pUserAccountID)

        //public UserRole DeleteUserRole(UserRole pUserRole)








        [HttpGet("Get/{pUserRoleID}/{pLanguageID}")]
        public IActionResult Get(int pUserRoleID, int pLanguageID)
        {
            Entities.Authentication.UserRole userRole = new Entities.Authentication.UserRole();
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

                    return Ok(authenticationAbstraction.GetUserRole(pUserRoleID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userRole.ErrorsDetected = true;
                    userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userRole);
                }
            }
            else
            {
                userRole.ErrorsDetected = true;
                userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userRole);
            }
        }


        [HttpGet("List/{pUserAccountID}/{pLanguageID}")]
        public IActionResult List(int pUserAccountID, int pLanguageID)
        {

            Entities.Authentication.UserRole userRole = new Entities.Authentication.UserRole();
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

                    return Ok(authenticationAbstraction.ListUserRoles(pUserAccountID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userRole.ErrorsDetected = true;
                    userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userRole);

                }
            }
            else
            {

                userRole.ErrorsDetected = true;
                userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userRole);
            }
        }




        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Authentication.UserRole pUserRole, int pUserAccountID)
        {
            Entities.Authentication.UserRole userRole = new Entities.Authentication.UserRole();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserRoledTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserRoledTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.InsertUserRole(pUserRole, pUserAccountID));
                    }
                    else
                    {

                        userRole.ErrorsDetected = true;
                        userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userRole);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userRole.ErrorsDetected = true;
                    userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userRole);
                }
            }
            else
            {

                userRole.ErrorsDetected = true;
                userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserRoledTo within Header"));
                return Unauthorized(userRole);
            }
        }






        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Authentication.UserRole pUserRole)
        {
            Entities.Authentication.UserRole userRole = new Entities.Authentication.UserRole();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserRoledTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserRoledTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.DeleteUserRole(pUserRole));
                    }
                    else
                    {

                        userRole.ErrorsDetected = true;
                        userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userRole);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userRole.ErrorsDetected = true;
                    userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userRole);
                }
            }
            else
            {

                userRole.ErrorsDetected = true;
                userRole.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserRoledTo within Header"));
                return Unauthorized(userRole);

            }
        }

        /*
        // GET: api/<UserRoleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserRoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserRoleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserRoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */



    }
}
