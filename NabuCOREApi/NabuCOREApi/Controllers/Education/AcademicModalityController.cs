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
    [Route("Education/AcademicModality")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]

    public class AcademicModalityController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AcademicModality API", 1, 0, 0, "");

        public AcademicModalityController(IConfiguration config)
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


        //public AcademicModality GetAcademicModality(int pAcademicModalityID, int pLanguageID)
        [HttpGet("Get/{pAcademicModalityID}/{pLanguageID}")]
        public IActionResult Get(int pAcademicModalityID, int pLanguageID)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
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

                    return Ok(educationAbstraction.GetAcademicModality(pAcademicModalityID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicModality.ErrorsDetected = true;
                    academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicModality);
                }
            }
            else
            {
                academicModality.ErrorsDetected = true;
                academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicModality);
            }
        }


        // public AcademicModality GetAcademicModalityByAlias(string pAlias, int pLanguageID)

        [HttpGet("Get/{pAlias}/{pLanguageID}")]
        public IActionResult Get(string pAlias, int pLanguageID)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
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

                    return Ok(educationAbstraction.GetAcademicModalityByAlias(pAlias, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicModality.ErrorsDetected = true;
                    academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicModality);
                }
            }
            else
            {
                academicModality.ErrorsDetected = true;
                academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicModality);
            }
        }

        //public AcademicModality[] ListAcademicModalities(int pLanguageID)
        [HttpGet("List/{pLanguageID}")]
        public IActionResult List(int pLanguageID)
        {

            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
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

                    return Ok(educationAbstraction.ListAcademicModalities(pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicModality.ErrorsDetected = true;
                    academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicModality);

                }
            }
            else
            {

                academicModality.ErrorsDetected = true;
                academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(academicModality);
            }
        }



        
        //public AcademicModality[] ListAcademicModalities(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider, int pLanguageID)
        [HttpPost("ListComplexModalities")]
        public IActionResult ListComplexModalities([FromBody] AcademicModalitiesRequest pListAcademicModalitysRequest)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicModalitydTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicModalitydTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.ListAcademicModalities(pListAcademicModalitysRequest.AcademicLevel, pListAcademicModalitysRequest.AcademicStage, pListAcademicModalitysRequest.EducationProvider, pListAcademicModalitysRequest.language.LanguageID.Value));
                    }
                    else
                    {

                        academicModality.ErrorsDetected = true;
                        academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicModality);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicModality.ErrorsDetected = true;
                    academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicModality);
                }
            }
            else
            {

                academicModality.ErrorsDetected = true;
                academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicModalitydTo within Header"));
                return Unauthorized(academicModality);
            }
        }


        //public AcademicModality InsertAcademicModality(AcademicModality pAcademicModality)
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Education.AcademicModality pAcademicModality)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicModalitydTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicModalitydTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.InsertAcademicModality(pAcademicModality));
                    }
                    else
                    {

                        academicModality.ErrorsDetected = true;
                        academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicModality);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicModality.ErrorsDetected = true;
                    academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicModality);
                }
            }
            else
            {

                academicModality.ErrorsDetected = true;
                academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicModalitydTo within Header"));
                return Unauthorized(academicModality);
            }
        }




        //public AcademicModality UpdateAcademicModality(AcademicModality pAcademicModality)

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Education.AcademicModality pAcademicModality)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicModalitydTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicModalitydTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.UpdateAcademicModality(pAcademicModality));
                    }
                    else
                    {

                        academicModality.ErrorsDetected = true;
                        academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicModality);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicModality.ErrorsDetected = true;
                    academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicModality);
                }
            }
            else
            {

                academicModality.ErrorsDetected = true;
                academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicModalitydTo within Header"));
                return Unauthorized(academicModality);
            }
        }


        //public AcademicModality DeleteAcademicModality(AcademicModality pAcademicModality)
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Education.AcademicModality pAcademicModality)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAcademicModalitydTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAcademicModalitydTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.DeleteAcademicModality(pAcademicModality));
                    }
                    else
                    {

                        academicModality.ErrorsDetected = true;
                        academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(academicModality);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    academicModality.ErrorsDetected = true;
                    academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(academicModality);
                }
            }
            else
            {

                academicModality.ErrorsDetected = true;
                academicModality.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAcademicModalitydTo within Header"));
                return Unauthorized(academicModality);

            }
        }

        
        //public AcademicModality AssignAcademicModality(pAcademicModalitysRequest.AcademicModality, pAcademicModalitysRequest.AcademicLevel, pAcademicModalitysRequest.AcademicStage,pAcademicModalitysRequest.EducationProvider)
       
        [HttpPost("Assign")]
        public IActionResult Assign([FromBody] AcademicModalitiesRequest pAcademicModalitysRequest)
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

                        return Ok(educationAbstraction.AssignAcademicModality(pAcademicModalitysRequest.AcademicModality, pAcademicModalitysRequest.AcademicLevel, pAcademicModalitysRequest.AcademicStage, pAcademicModalitysRequest.EducationProvider));
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

        //public AcademicModality RemoveAcademicModality(AcademicModality pAcademicModality, AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)

        [HttpDelete("Remove")]
        public IActionResult Remove([FromBody] AcademicModalitiesRequest pRemoveAcademicModalityRequest)
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

                        return Ok(educationAbstraction.RemoveAcademicModality(pRemoveAcademicModalityRequest.AcademicModality, pRemoveAcademicModalityRequest.AcademicLevel, pRemoveAcademicModalityRequest.AcademicStage, pRemoveAcademicModalityRequest.EducationProvider));
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
