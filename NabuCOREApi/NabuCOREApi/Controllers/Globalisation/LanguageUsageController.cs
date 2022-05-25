using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Octavo.Gate.Nabu.CORE.Abstraction;
using Octavo.Gate.Nabu.CORE.API.Helper;
using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Collections.Generic;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Globalisation
{
    [Route("Globalisation/LanguageUsage")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Globalisation")]
    public class LanguageUsageController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("LanguageUsageAPI", 1, 0, 0, "");

        public LanguageUsageController(IConfiguration config)
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
        /******************************************************************************************
         * LANGUAGE USAGE
         *****************************************************************************************/

        /// get general
        /// delete
        /// 

        ///get by id
        /////public LanguageUsage GetLanguageUsage(int pLanguageUsageID, int pLanguageID)
        [HttpGet("GetById/{pLanguageUsageID}")]
        
        public IActionResult GetById(int pLanguageUsageID, int pLanguageID)
        {
            LanguageUsage languageUsage = new LanguageUsage();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    GlobalisationAbstraction globalisationAbstraction = new GlobalisationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                    return Ok(globalisationAbstraction.GetLanguageUsage(pLanguageUsageID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    LanguageUsage error = new LanguageUsage();
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(error);
                }
            }
            else
            {
                LanguageUsage error = new LanguageUsage();
                error.ErrorsDetected = true;
                error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(error);
            }
        }

        
        
        [HttpGet("List")]
        ////listar
        /////public LanguageUsage[] ListLanguageUsages(int pLanguageID)
        public IActionResult List(int pLanguageID)
        {
            List<LanguageUsage> languageUsages = new List<LanguageUsage>();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    GlobalisationAbstraction globalisationAbstraction = new GlobalisationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                    return Ok(globalisationAbstraction.ListLanguageUsages(pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    LanguageUsage error = new LanguageUsage();
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, state.ToString()));
                    languageUsages.Add(error);
                    return Unauthorized(languageUsages.ToArray());
                }
            }
            else
            {
                LanguageUsage error = new LanguageUsage();
                error.ErrorsDetected = true;
                error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                languageUsages.Add(error);
                return Unauthorized(languageUsages.ToArray());
            }
        }

        /////POST
        //public LanguageUsage InsertLanguageUsage(LanguageUsage pLanguageUsage)

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] LanguageUsage pLanguageUsage)
        {
            LanguageUsage languageUsage = new LanguageUsage();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        GlobalisationAbstraction globalisationAbstraction = new GlobalisationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        return Ok(globalisationAbstraction.InsertLanguageUsage(pLanguageUsage));
                    }
                    else
                    {
                        LanguageUsage error = new LanguageUsage();
                        error.ErrorsDetected = true;
                        error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(error);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    LanguageUsage error = new LanguageUsage();
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(error);
                }
            }
            else
            {
                LanguageUsage error = new LanguageUsage();
                error.ErrorsDetected = true;
                error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(error);
            }
        }

        //Put edit
        //public LanguageUsage UpdateLanguageUsage(LanguageUsage pLanguageUsage)

        [HttpPut("Update")]
        public IActionResult Update([FromBody] LanguageUsage pLanguageUsage)
        {
            LanguageUsage languageUsage = new LanguageUsage();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        GlobalisationAbstraction globalisationAbstraction = new GlobalisationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        return Ok(globalisationAbstraction.UpdateLanguageUsage(pLanguageUsage));
                    }
                    else
                    {
                        LanguageUsage error = new LanguageUsage();
                        error.ErrorsDetected = true;
                        error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Private methods"));
                        return Unauthorized(error);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    LanguageUsage error = new LanguageUsage();
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(error);
                }
            }
            else
            {
                LanguageUsage error = new LanguageUsage();
                error.ErrorsDetected = true;
                error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(error);
            }
        }

        ///Delet
        ///public LanguageUsage DeleteLanguageUsage(LanguageUsage pLanguageUsage)

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] LanguageUsage pLanguageUsage)
        {
            LanguageUsage languageUsage = new LanguageUsage();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        GlobalisationAbstraction globalisationAbstraction = new GlobalisationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        return Ok(globalisationAbstraction.DeleteLanguageUsage(pLanguageUsage));
                    }
                    else
                    {
                        LanguageUsage error = new LanguageUsage();
                        error.ErrorsDetected = true;
                        error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(error);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    LanguageUsage error = new LanguageUsage();
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(error);
                }
            }
            else
            {
                LanguageUsage error = new LanguageUsage();
                error.ErrorsDetected = true;
                error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(error);
            }
        }


        
        
        


    }
}
