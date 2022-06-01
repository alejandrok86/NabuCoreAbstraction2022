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
using Octavo.Gate.Nabu.CORE.API.Helper.Education;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Education
{
    [Route("Education/AcademicLevel")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]
    public class AcademicLevelController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AcademicLevel API", 1, 0, 0, "");

        public AcademicLevelController(IConfiguration config)
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


        //public AcademicLevel GetAcademicLevel(int pAcademicLevelID, int pLanguageID)

        [HttpGet("Get/{pAcademicLevelID}/{pLanguageID}")]
        public IActionResult Get(int pAcademicLevelID, int pLanguageID)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
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

                    return Ok(educationAbstraction.GetAcademicLevel(pAcademicLevelID,  pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {
                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicLevel);
            }
        }

        //public AcademicLevel GetAcademicLevelByAlias(string pAlias, int pLanguageID)


        [HttpGet("Get/{pAlias}/{pLanguageID}")]
        public IActionResult Get(string pAlias, int pLanguageID)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
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

                    return Ok(educationAbstraction.GetAcademicLevelByAlias(pAlias,  pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {
                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicLevel);
            }
        }
        
        
        //public AcademicLevel[] ListAcademicLevels(int pLanguageID)

        [HttpGet("List/{pLanguageID}")]
        public IActionResult List(int pLanguageID)
        {

            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
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

                    return Ok(educationAbstraction.ListAcademicLevels(pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);

                }
            }
            else
            {

                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicLevel);
            }
        }


        
        
        ////public AcademicLevel[] ListAcademicLevels(AcademicStage pAcademicStage, EducationProvider pEducationProvider, int pLanguageID)
        [HttpPost("ListComplex")]
        public IActionResult ListComplex([FromBody] ListAcademicLevelsRequest pListAcademicLevelsRequest)
        {
           
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicLeveldTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicLeveldTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        
                        return Ok(educationAbstraction.ListAcademicLevels(pListAcademicLevelsRequest.AcademicStage, pListAcademicLevelsRequest.EducationProvider, pListAcademicLevelsRequest.language.LanguageID.Value));
                    
                        }

                    else
                    {

                        academicLevel.ErrorsDetected = true;
                        academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicLevel);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {

                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicLeveldTo within Header"));
                return Unauthorized(academicLevel);
            }
        }
        
        
        
        //public AcademicLevel InsertAcademicLevel(AcademicLevel pAcademicLevel)
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Education.AcademicLevel pAcademicLevel)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicLeveldTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicLeveldTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.InsertAcademicLevel(pAcademicLevel));
                    }
                    else
                    {

                        academicLevel.ErrorsDetected = true;
                        academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicLevel);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {

                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicLeveldTo within Header"));
                return Unauthorized(academicLevel);
            }
        }



        //public AcademicLevel UpdateAcademicLevel(AcademicLevel pAcademicLevel)
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Education.AcademicLevel pAcademicLevel)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicLeveldTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicLeveldTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.UpdateAcademicLevel(pAcademicLevel));
                    }
                    else
                    {

                        academicLevel.ErrorsDetected = true;
                        academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicLevel);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {

                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicLeveldTo within Header"));
                return Unauthorized(academicLevel);
            }
        }



        //public AcademicLevel DeleteAcademicLevel(AcademicLevel pAcademicLevel)

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Education.AcademicLevel pAcademicLevel)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicLeveldTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicLeveldTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.DeleteAcademicLevel(pAcademicLevel));
                    }
                    else
                    {

                        academicLevel.ErrorsDetected = true;
                        academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicLevel);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {

                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicLeveldTo within Header"));
                return Unauthorized(academicLevel);

            }
        }



        


        //ver estos metodos si son correctos

        
        //  public AcademicLevel AssignAcademicLevel(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)

        [HttpPost("Assign")]
        public IActionResult Assign([FromBody] AssingRequest pAssingRequest)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicLeveldTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicLeveldTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.AssignAcademicLevel(pAssingRequest.AcademicLevel, pAssingRequest.AcademicStage, pAssingRequest.EducationProvider));
                    }
                    else
                    {

                        academicLevel.ErrorsDetected = true;
                        academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicLevel);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {

                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicLeveldTo within Header"));
                return Unauthorized(academicLevel);
            }
        }

        

        //public AcademicLevel RemoveAcademicLevel(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        [HttpDelete("Remove")]
        public IActionResult Remove([FromBody] AssingRequest pAssingRequest)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicLeveldTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicLeveldTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.RemoveAcademicLevel(pAssingRequest.AcademicLevel, pAssingRequest.AcademicStage, pAssingRequest.EducationProvider));
                    }
                    else
                    {

                        academicLevel.ErrorsDetected = true;
                        academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicLevel);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicLevel.ErrorsDetected = true;
                    academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicLevel);
                }
            }
            else
            {

                academicLevel.ErrorsDetected = true;
                academicLevel.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicLeveldTo within Header"));
                return Unauthorized(academicLevel);

            }
        }

        
    }
}
