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
using Octavo.Gate.Nabu.CORE.API.Helper.Authentication;



using System.Data;
using Microsoft.Data.SqlClient;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Authentication
{
    [Route("Authentication/UserAccountSession")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication")]
    public class UserAccountSessionController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AuthenticationToken API", 1, 0, 0, "");

        public UserAccountSessionController(IConfiguration config)
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

       
       // public UserAccountSession Logout(UserAccountSession pUserAccountSession, int pLanguageID)
        [HttpPost("Logout")]
        public IActionResult Logout( [FromBody] LogoutRequest pLogoutRequest)
        {
            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
                
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountSessiondTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountSessiondTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                                                   
                        if (pLogoutRequest.sessionEndStatus == null)
                           
                        {
                            
                           Octavo.Gate.Nabu.CORE.DOL.MSSQL.System.SessionEndStatusDOL DOL = new CORE.DOL.MSSQL.System.SessionEndStatusDOL(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                          pLogoutRequest.sessionEndStatus = DOL.GetByAlias("LOGOUT", pLogoutRequest.language.LanguageID.Value);
                           
                            return Ok(authenticationAbstraction.Logout(pLogoutRequest.userAccountSession, pLogoutRequest.language.LanguageID.Value));
                        }
                        else
                         {
                            return Ok(authenticationAbstraction.Logout(pLogoutRequest.userAccountSession, pLogoutRequest.language.LanguageID.Value));

                        }
                        
                    }
                    else
                    {

                        userAccountSession.ErrorsDetected = true;
                        userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountSession);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);
                }
            }
            else
            {

                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountSessiondTo within Header"));
                return Unauthorized(userAccountSession);
            }
        }




        //public BaseBoolean UserAccountSessionHeartbeat(int pUserAccountSessionID)
        [HttpPost("UserAccountSessionHeartbeat")]
        public IActionResult UserAccountSessionHeartbeat([FromBody] int pUserAccountSessionID)
        {
            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.UserAccountSessionHeartbeat(pUserAccountSessionID));
                    }
                    else
                    {

                        userAccount.ErrorsDetected = true;
                        userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccount);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);
                }
            }
            else
            {

                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountdTo within Header"));
                return Unauthorized(userAccount);
            }
        }



        //public UserAccountSession GetUserAccountSession(int pUserAccountSessionID, int pLanguageID)
        [HttpGet("Get/{pUserAccountSessionID}/{pLanguageID}")]
        public IActionResult Get(int pUserAccountSessionID, int pLanguageID)
        {
            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
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

                    return Ok(authenticationAbstraction.GetUserAccountSession(pUserAccountSessionID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);
                }
            }
            else
            {
                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccountSession);
            }
        }


        //public UserAccountSession[] ListUserAccountSessions(int pUserAccountID, int pLanguageID)

       [HttpGet("List/{pUserAccountSessionID}/{pLanguageID}")]
        public IActionResult List(int pUserAccountSessionID, int pLanguageID)
        {

            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
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

                    return Ok(authenticationAbstraction.ListUserAccountSessions(pUserAccountSessionID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);

                }
            }
            else
            {

                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccountSession);
            }
        }

        // public UserAccountSession InsertUserAccountSession(UserAccountSession pUserAccountSession)
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Authentication.UserAccountSession pUserAccountSession)
        {
            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountSessiondTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountSessiondTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.InsertUserAccountSession(pUserAccountSession));
                    }
                    else
                    {

                        userAccountSession.ErrorsDetected = true;
                        userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountSession);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);
                }
            }
            else
            {

                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountSessiondTo within Header"));
                return Unauthorized(userAccountSession);
            }
        }


        //public UserAccountSession UpdateUserAccountSession(UserAccountSession pUserAccountSession)
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Authentication.UserAccountSession pUserAccountSession)
        {
            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountSessiondTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountSessiondTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.UpdateUserAccountSession(pUserAccountSession));
                    }
                    else
                    {

                        userAccountSession.ErrorsDetected = true;
                        userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountSession);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);
                }
            }
            else
            {

                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountSessiondTo within Header"));
                return Unauthorized(userAccountSession);
            }
        }

        //public UserAccountSession DeleteUserAccountSession(UserAccountSession pUserAccountSession)
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Authentication.UserAccountSession pUserAccountSession)
        {
            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountSessiondTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountSessiondTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.DeleteUserAccountSession(pUserAccountSession));
                    }
                    else
                    {

                        userAccountSession.ErrorsDetected = true;
                        userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountSession);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);
                }
            }
            else
            {

                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountSessiondTo within Header"));
                return Unauthorized(userAccountSession);

            }
        }

        
        //public BaseBoolean DeleteUserAccountSessions(UserAccount pUserAccount)
        [HttpDelete("DeleteUserAccountSessions")]
       
        public IActionResult DeleteUserAccountSessions([FromBody] Entities.Authentication.UserAccount pUserAccount)
        {
            Entities.Authentication.UserAccountSession userAccountSession = new Entities.Authentication.UserAccountSession();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIUserAccountSessiondTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIUserAccountSessiondTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.DeleteUserAccountSessions(pUserAccount));
                    }
                    else
                    {

                        userAccountSession.ErrorsDetected = true;
                        userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(userAccountSession);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccountSession.ErrorsDetected = true;
                    userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccountSession);
                }
            }
            else
            {

                userAccountSession.ErrorsDetected = true;
                userAccountSession.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIUserAccountSessiondTo within Header"));
                return Unauthorized(userAccountSession);

            }
        }
       
    }
}
