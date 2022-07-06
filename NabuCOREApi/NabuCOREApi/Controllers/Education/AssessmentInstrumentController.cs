using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Octavo.Gate.Nabu.CORE.Abstraction;
using Octavo.Gate.Nabu.CORE.API.Helper;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.API.Helper.Education;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.Education
{
    [Route("Education/AssessmentInstrument")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Education")]
    public class AssessmentInstrumentController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("AssessmentInstrument API", 1, 0, 0, "");

        public AssessmentInstrumentController(IConfiguration config)
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
        /************************************************************************************************************************************
         * List
         ***********************************************************************************************************************************/
        /* public AssessmentInstrument[] ListAssessmentInstruments(int pUnitID, int pLanguageID)
         * 
         *
        [HttpGet("Get/{pLanguageID}/{pAssessmentInstrumentID}")]
        public IActionResult Get(int pLanguageID, int pAssessmentInstrumentID)
        {
            Entities.Authentication.AuthenticationToken authenticationToken = new Entities.Authentication.AuthenticationToken();
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

                    return Ok(educationAbstraction.GetAssessmentInstrument(pAssessmentInstrumentID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    authenticationToken.ErrorsDetected = true;
                    authenticationToken.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(authenticationToken);
                }
            }
            else
            {
                authenticationToken.ErrorsDetected = true;
                authenticationToken.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(authenticationToken);
            }
        }
        */

        //public AssessmentInstrument GetAssessmentInstrument(int pAssessmentInstrumentID, int pLanguageID)
        [HttpGet("Get/{pAssessmentInstrumentID}/{pLanguageID}")]
        public IActionResult Get(int pAssessmentInstrumentID, int pLanguageID)
        {
            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
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

                    return Ok(educationAbstraction.GetAssessmentInstrument(pAssessmentInstrumentID, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);
                }
            }
            else
            {
                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(assessmentInstrument);
            }
        }

        //public AssessmentInstrument GetAssessmentInstrumentByPartCode(string pPartCode, int pLanguageID)
        [HttpGet("Get/{pPartCode}/{pLanguageID}")]
        public IActionResult Get(string pPartCode, int pLanguageID)
        {
            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
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

                    return Ok(educationAbstraction.GetAssessmentInstrumentByPartCode(pPartCode, pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);
                }
            }
            else
            {
                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(assessmentInstrument);
            }
        }

        //public AssessmentInstrument[] ListAssessmentInstruments(int pLanguageID)
        [HttpGet("List/{pLanguageID}")]
        public IActionResult List(int pLanguageID)
        {

            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
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

                    return Ok(educationAbstraction.ListAssessmentInstruments(pLanguageID));
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);

                }
            }
            else
            {

                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(assessmentInstrument);
            }
        }


        //AssessmentInstrumentRequest
        ///ERROR
        //public AssessmentInstrument[] ListAssessmentInstruments(int pUnitID, int pLanguageID)
        [HttpPost("ListComplexAssessmentInstruments")]
        public IActionResult ListComplexAssessmentInstruments([FromBody] Octavo.Gate.Nabu.CORE.API.Helper.Education.AssessmentInstrumentRequest pAssessmentInstrumentRequest)
        {
            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAssessmentInstrumentdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAssessmentInstrumentdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.ListAssessmentInstruments(pAssessmentInstrumentRequest.pUnitID.Value, pAssessmentInstrumentRequest.language.LanguageID.Value));
                    }
                    else
                    {

                        assessmentInstrument.ErrorsDetected = true;
                        assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(assessmentInstrument);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);
                }
            }
            else
            {

                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAssessmentInstrumentdTo within Header"));
                return Unauthorized(assessmentInstrument);
            }
        }

        ///ERROR
        //public AssessmentInstrument[] ListAssessmentInstruments(Octavo.Gate.Nabu.CORE.Entities.Core.Party pOwnedBy, int pLanguageID)
        [HttpPost("ListComplexAssessmentParty")]
        public IActionResult ListComplexAssessmentParty([FromBody] Octavo.Gate.Nabu.CORE.API.Helper.Education.AssessmentInstrumentRequest pAssessmentInstrumentRequest)
        {
            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAssessmentInstrumentdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAssessmentInstrumentdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.ListAssessmentInstruments(pAssessmentInstrumentRequest.pOwnedBy, pAssessmentInstrumentRequest.language.LanguageID.Value));
                    }
                    else
                    {

                        assessmentInstrument.ErrorsDetected = true;
                        assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(assessmentInstrument);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);
                }
            }
            else
            {

                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAssessmentInstrumentdTo within Header"));
                return Unauthorized(assessmentInstrument);
            }
        }


        // public AssessmentInstrument InsertAssessmentInstrument(AssessmentInstrument pAssessmentInstrument)
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] Entities.Education.AssessmentInstrument pAssessmentInstrument)
        {
            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAssessmentInstrumentdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAssessmentInstrumentdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.InsertAssessmentInstrument(pAssessmentInstrument));
                    }
                    else
                    {

                        assessmentInstrument.ErrorsDetected = true;
                        assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(assessmentInstrument);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);
                }
            }
            else
            {

                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAssessmentInstrumentdTo within Header"));
                return Unauthorized(assessmentInstrument);
            }
        }




        //public AssessmentInstrument UpdateAssessmentInstrument(AssessmentInstrument pAssessmentInstrument)
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Entities.Education.AssessmentInstrument pAssessmentInstrument)
        {
            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAssessmentInstrumentdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAssessmentInstrumentdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokePrivateMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.UpdateAssessmentInstrument(pAssessmentInstrument));
                    }
                    else
                    {

                        assessmentInstrument.ErrorsDetected = true;
                        assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(assessmentInstrument);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);
                }
            }
            else
            {

                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAssessmentInstrumentdTo within Header"));
                return Unauthorized(assessmentInstrument);
            }
        }



        //public AssessmentInstrument DeleteAssessmentInstrument(AssessmentInstrument pAssessmentInstrument)
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Entities.Education.AssessmentInstrument pAssessmentInstrument)
        {
            Entities.Education.AssessmentInstrument assessmentInstrument = new Entities.Education.AssessmentInstrument();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APIAssessmentInstrumentdTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APIAssessmentInstrumentdTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    if (apiAccess.InvokeProtectedMethods)
                    {
                        EducationAbstraction educationAbstraction = new EducationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        return Ok(educationAbstraction.DeleteAssessmentInstrument(pAssessmentInstrument));
                    }
                    else
                    {

                        assessmentInstrument.ErrorsDetected = true;
                        assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "You do not have permission to invoke Protected methods"));
                        return Unauthorized(assessmentInstrument);
                    }
                }
                else
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    assessmentInstrument.ErrorsDetected = true;
                    assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(assessmentInstrument);
                }
            }
            else
            {

                assessmentInstrument.ErrorsDetected = true;
                assessmentInstrument.ErrorDetails.Add(new Octavo.Gate.Nabu.CORE.Entities.Error.ErrorDetail(-1, "Missing APIKey/APIAssessmentInstrumentdTo within Header"));
                return Unauthorized(assessmentInstrument);

            }
        }


    }
}
