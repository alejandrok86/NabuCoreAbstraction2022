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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Authentication
{
    [Route("Authentication/UserAccount")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Authentication")]
    public class UserAccountController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AuthenticationToken API", 1, 0, 0, "");

        public UserAccountController(IConfiguration config)
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


        // public UserAccountSession EncryptedLogin(string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, bool pUserAccountIDAsExtraSalt)
        // * Este metodo esta duplicado, en el AuthenticationAbstraction consultar con KRIS
        // * o si se implementa como un GET consultar con KRIS
        //* 
        ///public UserAccountSession EncryptedLogin(string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, bool pUserAccountIDAsExtraSalt)
        //Post 
        // this method Post it is ok?  

        [HttpPost("EncryptedLogin")]
        public IActionResult EncryptedLogin([FromBody] EncriptedLogRequest pEncriptedLogRequest)
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

                        return Ok(authenticationAbstraction.EncryptedLogin(pEncriptedLogRequest.pAccountName, pEncriptedLogRequest.pUnEncryptedPassword, pEncriptedLogRequest.pIPAddress, pEncriptedLogRequest.language.LanguageID.Value, pEncriptedLogRequest.pUserAccountIDAsExtraSalt));
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

        


        /*
        //public UserAccountSession EncryptedLogin(string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections, bool pUserAccountIDAsExtraSalt)
        //Post 
        // this method Post it is ok? (to EncryptedLogin)
        [HttpPost("EncryptedLogin")]
        public IActionResult EncryptedLogin([FromBody] string pAccountName, string pUnEncryptedPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections, bool pUserAccountIDAsExtraSalt)
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

                       // return Ok(authenticationAbstraction.EncryptedLogin( pAccountName, pUnEncryptedPassword, pIPAddress, pLanguageID, pNumberOfDaysBetweenPasswordChange, pInvalidAttemptsBeforeAccountLock, bAllowConcurrentConnections, pUserAccountIDAsExtraSalt));
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

        */
          
        // public UserAccountSession Login(string pAccountName, string pPassword, string pIPAddress, int pLanguageID)
        //Post 
        // this method Post it is ok? (to EncryptedLogin)
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest pLoginRequest)
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

                        return Ok(authenticationAbstraction.Login(pLoginRequest.pAccountName, pLoginRequest.pPassword, pLoginRequest.pIPAddress,pLoginRequest.language.LanguageID.Value));
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

        


        /*
        /// public UserAccountSession Login(string pAccountName, string pPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections)
        //Post 
        // this method Post it is ok? (to EncryptedLogin)
        [HttpPost("Login")]
        public IActionResult Login([FromBody] string pAccountName, string pPassword, string pIPAddress, int pLanguageID, int pNumberOfDaysBetweenPasswordChange, int pInvalidAttemptsBeforeAccountLock, bool bAllowConcurrentConnections)
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

                        return Ok(authenticationAbstraction.Login( pAccountName,  pPassword,  pIPAddress,  pLanguageID,  pNumberOfDaysBetweenPasswordChange,  pInvalidAttemptsBeforeAccountLock,  bAllowConcurrentConnections));
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


        */


        /*
        // GET: api/<UserAccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */


        // get by Name
        //public UserAccount GetUserAccountByName(string pAccountName, int pLanguageID)

        [HttpGet("Get/{pAccountName}/{pLanguageID}/")]
        public IActionResult GetName(string pAccountName, int pLanguageID)
        {
            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
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

                    return Ok(authenticationAbstraction.GetUserAccountByName(pAccountName, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);
                }
            }
            else
            {
                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccount);
            }
        }


        //
        // get by TelephoneNumber
        //public UserAccount GetUserAccountByTelephoneNumber(string pTelephoneNumber, int pLanguageID)

        [HttpGet("Get/{pTelephoneNumber}/{pLanguageID}/")]
        public IActionResult GetTelephone(string pTelephoneNumber, int pLanguageID)
        {
            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
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

                    return Ok(authenticationAbstraction.GetUserAccountByTelephoneNumber(pTelephoneNumber,pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);
                }
            }
            else
            {
                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccount);
            }
        }

        //get by UserAccount
        //public UserAccount GetUserAccount(int pUserAccountID, int pLanguageID)
        [HttpGet("Get/{pUserAccountID}/{pLanguageID}/")]
        public IActionResult Get(int pUserAccountID, int pLanguageID)
        {
            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
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

                    return Ok(authenticationAbstraction.GetUserAccount(pUserAccountID,pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);
                }
            }
            else
            {
                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccount);
            }
        }

        /// ########
        /// List
        /// public UserAccount[] ListUserAccounts(int pLanguageID)


        [HttpGet("List/{pLanguageID}")]
        public IActionResult List(int pLanguageID)
        {

            Entities.Authentication.UserAccount userAccount = new Entities.Authentication.UserAccount();
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
                    
                    return Ok(authenticationAbstraction.ListUserAccounts(pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    userAccount.ErrorsDetected = true;
                    userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(userAccount);

                }
            }
            else
            {

                userAccount.ErrorsDetected = true;
                userAccount.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(userAccount);
            }
        }




        //insert
        //public UserAccount InsertUserAccount(UserAccount pUserAccount)
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Authentication.UserAccount pUserAccount)
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

                        return Ok(authenticationAbstraction.InsertUserAccount(pUserAccount));
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


        //
        // PUT
        //public UserAccount UpdateUserAccount(UserAccount pUserAccount)

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Authentication.UserAccount pUserAccount)
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

                    if (apiAccess.InvokePrivateMethods)
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(authenticationAbstraction.UpdateUserAccount(pUserAccount));
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






        // DELETE 
        //public UserAccount DeleteUserAccount(UserAccount pUserAccount)

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Authentication.UserAccount pUserAccount)
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

                        return Ok(authenticationAbstraction.DeleteUserAccount(pUserAccount));
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









        /*

        // POST api/<UserAccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserAccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
