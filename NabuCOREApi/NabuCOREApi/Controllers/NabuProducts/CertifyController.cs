using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Octavo.Gate.Nabu.CORE.Abstraction;
using Octavo.Gate.Nabu.CORE.API.Helper;
using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Octavo.Gate.Nabu.CORE.API.Controllers.NabuProducts
{
    [Route("NabuProducts/Certify")]
    [ApiExplorerSettings(GroupName = "NabuProducts")]
    [ApiController]
    public class CertifyController : ControllerBase
    {
        private IConfiguration _config;
        private BaseVersion release = new BaseVersion("Nabu - Products - Certify API", 1, 0, 0, "");

        public CertifyController(IConfiguration config)
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
         * INSTRUMENTS
         *****************************************************************************************/
        [HttpGet("ListActiveInstruments")]
        public IActionResult ListActiveInstruments()
        {
            RecordSet recordSet = new RecordSet();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    ResponseAbstraction responseAbstraction = new ResponseAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                    string SQL = "";
                    SQL += "SELECT DISTINCT(i.InstrumentID),tr.TranslatedName";
                    SQL += " FROM [SchCore].[Instrument] i";
                    SQL += " INNER JOIN [SchOperations].[Part] p ON p.PartID = i.InstrumentID";
                    SQL += " INNER JOIN [SchGlobalisation].TranslatedResource tr ON tr.TranslationID = p.TranslationID";
                    SQL += " INNER JOIN [SchEducation].[UnitInstrument] ui ON ui.InstrumentID = i.InstrumentID";
                    SQL += " ORDER BY tr.TranslatedName";

                    BaseString[] strRecordSet = responseAbstraction.CustomQuery(SQL);
                    foreach (BaseString strRecord in strRecordSet)
                    {
                        Record record = new Record();
                        if (strRecord.ErrorsDetected == false)
                        {
                            string[] strFields = strRecord.GetFields();
                            record.fields.Add(new Field("InstrumentID", strFields[0].Replace("'", "")));
                            record.fields.Add(new Field("TranslatedName", strFields[1].Replace("'", "")));
                        }
                        else
                        {
                            record.hasErrors = true;
                            record.errorMessage = strRecord.ErrorDetails[0].ErrorMessage;
                        }
                        recordSet.records.Add(record);
                    }
                    return Ok(recordSet);
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    recordSet.hasErrors = true;
                    recordSet.errorMessage = state.ToString();
                    return Unauthorized(recordSet);
                }
            }
            else
            {
                recordSet.hasErrors = true;
                recordSet.errorMessage = "Missing APIKey/APILicensedTo within Header";
                return Unauthorized(recordSet);
            }
        }
        [HttpGet("ListActiveLearningInstruments")]
        public IActionResult ListActiveLearningInstruments()
        {
            RecordSet recordSet = new RecordSet();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));
                    ResponseAbstraction responseAbstraction = new ResponseAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                    string SQL = "";
                    SQL += "SELECT DISTINCT(i.InstrumentID),tr.TranslatedName";
                    SQL += " FROM [SchCore].[Instrument] i";
                    SQL += " INNER JOIN [SchEducation].[LearningInstrument] li ON li.InstrumentID = i.InstrumentID";
                    SQL += " INNER JOIN [SchOperations].[Part] p ON p.PartID = i.InstrumentID";
                    SQL += " INNER JOIN [SchGlobalisation].TranslatedResource tr ON tr.TranslationID = p.TranslationID";
                    SQL += " INNER JOIN [SchEducation].[UnitInstrument] ui ON ui.InstrumentID = i.InstrumentID";
                    SQL += " ORDER BY tr.TranslatedName";

                    BaseString[] strRecordSet = responseAbstraction.CustomQuery(SQL);
                    foreach (BaseString strRecord in strRecordSet)
                    {
                        Record record = new Record();
                        if (strRecord.ErrorsDetected == false)
                        {
                            string[] strFields = strRecord.GetFields();
                            record.fields.Add(new Field("InstrumentID", strFields[0].Replace("'", "")));
                            record.fields.Add(new Field("TranslatedName", strFields[1].Replace("'", "")));
                        }
                        else
                        {
                            record.hasErrors = true;
                            record.errorMessage = strRecord.ErrorDetails[0].ErrorMessage;
                        }
                        recordSet.records.Add(record);
                    }
                    return Ok(recordSet);
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    recordSet.hasErrors = true;
                    recordSet.errorMessage = state.ToString();
                    return Unauthorized(recordSet);
                }
            }
            else
            {
                recordSet.hasErrors = true;
                recordSet.errorMessage = "Missing APIKey/APILicensedTo within Header";
                return Unauthorized(recordSet);
            }
        }
        [HttpGet("ListActiveAssessmentInstruments")]
        public IActionResult ListActiveAssessmentInstruments()
        {
            RecordSet recordSet = new RecordSet();
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));
                    ResponseAbstraction responseAbstraction = new ResponseAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                    string SQL = "";
                    SQL += "SELECT DISTINCT(i.InstrumentID),tr.TranslatedName";
                    SQL += " FROM [SchCore].[Instrument] i";
                    SQL += " INNER JOIN [SchEducation].[AssessmentInstrument] ai ON ai.InstrumentID = i.InstrumentID";
                    SQL += " INNER JOIN [SchOperations].[Part] p ON p.PartID = i.InstrumentID";
                    SQL += " INNER JOIN [SchGlobalisation].TranslatedResource tr ON tr.TranslationID = p.TranslationID";
                    SQL += " INNER JOIN [SchEducation].[UnitInstrument] ui ON ui.InstrumentID = i.InstrumentID";
                    SQL += " ORDER BY tr.TranslatedName";

                    BaseString[] strRecordSet = responseAbstraction.CustomQuery(SQL);
                    foreach (BaseString strRecord in strRecordSet)
                    {
                        Record record = new Record();
                        if (strRecord.ErrorsDetected == false)
                        {
                            string[] strFields = strRecord.GetFields();
                            record.fields.Add(new Field("InstrumentID", strFields[0].Replace("'", "")));
                            record.fields.Add(new Field("TranslatedName", strFields[1].Replace("'", "")));
                        }
                        else
                        {
                            record.hasErrors = true;
                            record.errorMessage = strRecord.ErrorDetails[0].ErrorMessage;
                        }
                        recordSet.records.Add(record);
                    }
                    return Ok(recordSet);
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    recordSet.hasErrors = true;
                    recordSet.errorMessage = state.ToString();
                    return Unauthorized(recordSet);
                }
            }
            else
            {
                recordSet.hasErrors = true;
                recordSet.errorMessage = "Missing APIKey/APILicensedTo within Header";
                return Unauthorized(recordSet);
            }
        }
        /******************************************************************************************
         * PROGRESS
         *****************************************************************************************/
        [HttpPost("ListInstrumentProgress")]
        public IActionResult ListInstrumentProgress([FromBody]BaseString pAuthenticationToken)
        {
            RecordSet recordSet = new RecordSet();
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
                    GlobalisationAbstraction globalisationAbstraction = new GlobalisationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                    ResponseAbstraction responseAbstraction = new ResponseAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                    Language language = globalisationAbstraction.GetLanguageBySystemName("English");
                    if (language.ErrorsDetected == false && language.LanguageID.HasValue)
                    {
                        string SQL = "";
                        SQL += "SELECT";
                        SQL += " res.ResponseID,";                  // 0
                        SQL += " li.[InstrumentID],";               // 1
                        SQL += " lir.[State],";                     // 2
                        SQL += " ai.[InstrumentID],";               // 3
                        SQL += " air.[State],";                     // 4
                        SQL += " ro.[NumericalOutcome],";           // 5
                        SQL += " li.[LearningInstrumentID],";       // 6
                        SQL += " ai.[AssessmentInstrumentID]";      // 7
                        SQL += " FROM [SchResponse].[Response] res";
                        SQL += " INNER JOIN [SchAuthentication].[AuthenticationToken] tok ON tok.PartyID = res.RespondentID";
                        SQL += " LEFT OUTER JOIN [SchResponse].[LearningInstrumentResponse] lir ON lir.LearningInstrumentResponseID = res.ResponseID";
                        SQL += " LEFT OUTER JOIN [SchResponse].[AssessmentInstrumentResponse] air ON air.AssessmentInstrumentResponseID = res.ResponseID";
                        SQL += " LEFT OUTER JOIN [SchEducation].[LearningInstrument] li ON li.LearningInstrumentID = lir.LearningInstrumentID";
                        SQL += " LEFT OUTER JOIN [SchEducation].[AssessmentInstrument] ai ON ai.AssessmentInstrumentID = air.AssessmentInstrumentID";
                        SQL += " LEFT OUTER JOIN [SchResponse].[ResponseOutcome] ro ON ro.ResponseID = res.ResponseID";
                        SQL += " WHERE tok.Token = '" + pAuthenticationToken.Value + "'";

                        BaseString[] strRecordSet = responseAbstraction.CustomQuery(SQL);
                        foreach (BaseString strRecord in strRecordSet)
                        {
                            Record record = new Record();
                            if (strRecord.ErrorsDetected == false)
                            {
                                string[] strFields = strRecord.GetFields();
                                record.fields.Add(new Field("ResponseID", strFields[0].Replace("'", "")));
                                record.fields.Add(new Field("LearningInstrumentID", strFields[1].Replace("'", "")));
                                record.fields.Add(new Field("LearningInstrumentState", strFields[2].Replace("'", "")));
                                record.fields.Add(new Field("AssessmentInstrumentID", strFields[3].Replace("'", "")));
                                if (strFields[4].Replace("'", "").Length > 0)
                                {
                                    string assessmentInstrumentState = strFields[4].Replace("'", "");
                                    AssessmentInstrument assessmentInstrument = educationAbstraction.GetAssessmentInstrument(Convert.ToInt32(strFields[7].Replace("'", "")), (int)language.LanguageID);
                                    if (assessmentInstrument.ErrorsDetected == false && assessmentInstrument.AssessmentInstrumentID.HasValue)
                                    {
                                        Octavo.Gate.Nabu.CORE.Certificate.Renderer certificateRenderer = new Certificate.Renderer();
                                        double numericalOutcome = Convert.ToDouble(strFields[5].Replace("'", ""));
                                        if (Convert.ToDouble(certificateRenderer.GetDisplayScore(numericalOutcome, assessmentInstrument.AssessmentInstrumentAttributes)) < Convert.ToDouble(certificateRenderer.GetPassMarkPercentage(assessmentInstrument.AssessmentInstrumentAttributes)))
                                        {
                                            // failed
                                            assessmentInstrumentState = "Failed";
                                        }
                                        else
                                        {
                                            // passed
                                            assessmentInstrumentState = "Passed";
                                        }
                                    }
                                    record.fields.Add(new Field("AssessmentInstrumentState", assessmentInstrumentState));

                                    AssessmentInstrumentResponse assessmentInstrumentResponse = responseAbstraction.GetAssessmentInstrumentResponse(Convert.ToInt32(strFields[0].Replace("'", "")));
                                    if (assessmentInstrumentResponse != null && assessmentInstrumentResponse.ErrorsDetected == false && assessmentInstrumentResponse.ResponseID.HasValue)
                                    {
                                        record.fields.Add(new Field("Attempt", assessmentInstrumentResponse.Attempt.ToString() + " of " + assessmentInstrument.MaximumAttempts.ToString()));
                                        record.fields.Add(new Field("Started", assessmentInstrumentResponse.Started.Value.ToString("dd-MMM-yyyy HH:mm:ss")));
                                        record.fields.Add(new Field("Ended", assessmentInstrumentResponse.Ended.Value.ToString("dd-MMM-yyyy HH:mm:ss")));
                                    }
                                }
                                else
                                {
                                    LearningInstrumentResponse learningInstrumentResponse = responseAbstraction.GetLearningInstrumentResponse(Convert.ToInt32(strFields[0].Replace("'", "")));
                                    if (learningInstrumentResponse != null && learningInstrumentResponse.ErrorsDetected == false && learningInstrumentResponse.ResponseID.HasValue)
                                    {
                                        record.fields.Add(new Field("Attempt", learningInstrumentResponse.Attempt.ToString()));
                                        record.fields.Add(new Field("Started", learningInstrumentResponse.Started.Value.ToString("dd-MMM-yyyy HH:mm:ss")));
                                        record.fields.Add(new Field("Ended", learningInstrumentResponse.Ended.Value.ToString("dd-MMM-yyyy HH:mm:ss")));
                                    }

                                }
                            }
                            else
                            {
                                record.hasErrors = true;
                                record.errorMessage = strRecord.ErrorDetails[0].ErrorMessage;
                            }
                            recordSet.records.Add(record);
                        }
                    }
                    return Ok(recordSet);
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    recordSet.hasErrors = true;
                    recordSet.errorMessage = state.ToString();
                    return Unauthorized(recordSet);
                }
            }
            else
            {
                recordSet.hasErrors = true;
                recordSet.errorMessage = "Missing APIKey/APILicensedTo within Header";
                return Unauthorized(recordSet);
            }
        }
        /******************************************************************************************
         * CERTIFICATE
         *****************************************************************************************/
        [HttpGet("GetPNGCertificate/{pResponseID}")]
        public IActionResult GetPNGCertificate(int pResponseID)
        {
            BaseString certificateURL = new BaseString("");
            if (Request.Headers.ContainsKey("APIKey") && Request.Headers.ContainsKey("APILicensedTo"))
            {
                MethodBase method = MethodBase.GetCurrentMethod();
                APIAccessKey apiAccess = new APIAccessKey();
                APIKeyState state = apiAccess.ValidateKey(_config.GetValue<string>("APIKeyConfig:Filename"), Request.Headers["APIKey"], Request.Headers["APILicensedTo"]);
                if (state == APIKeyState.KeyValidAccessGranted)
                {
                    if (apiAccess.AuditActivity)
                        apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    try
                    {
                        AuthenticationAbstraction authenticationAbstraction = new AuthenticationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        GlobalisationAbstraction globalisationAbstraction = new GlobalisationAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        OperationsAbstraction operationsAbstraction = new OperationsAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        PeopleAndPlacesAbstraction peopleAndPlacesAbstraction = new PeopleAndPlacesAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));
                        ResponseAbstraction responseAbstraction = new ResponseAbstraction(_config.GetValue<string>("Octavo.Gate.Nabu.Data:Source"), DatabaseType.MSSQL, _config.GetValue<string>("Octavo.Gate.Nabu.Data:ErrorLogFile"));

                        Language language = globalisationAbstraction.GetLanguageBySystemName("English");
                        if(language != null && language.ErrorsDetected == false && language.LanguageID.HasValue)
                        {
                            Entities.Response.Response response = responseAbstraction.GetResponse(pResponseID, language.LanguageID.Value);
                            if (response != null && response.ErrorsDetected == false && response.ResponseID.HasValue)
                            {
                                string candidateName = "";

                                Entities.Authentication.UserAccount userAccount = authenticationAbstraction.GetUserAccount(response.Respondent.PartyID.Value, language.LanguageID.Value);
                                if (userAccount != null && userAccount.ErrorsDetected == false && userAccount.PartyID.HasValue)
                                {
                                    Octavo.Gate.Nabu.CORE.Encryption.EncryptorDecryptor encryptorDecryptor = new Encryption.EncryptorDecryptor();
                                    candidateName = encryptorDecryptor.Decrypt(userAccount.AccountName);
                                }
                                else
                                {
                                    Entities.Authentication.AuthenticationToken[] authenticationTokens = authenticationAbstraction.ListAuthenticationTokensByPartyID(response.Respondent.PartyID.Value, language.LanguageID.Value);
                                    if (authenticationTokens != null && authenticationTokens.Length == 1 && authenticationTokens[0].ErrorsDetected == false && authenticationTokens[0].AuthenticationTokenID.HasValue)
                                    {
                                        candidateName = authenticationTokens[0].Token;
                                    }
                                }

                                Entities.PeopleAndPlaces.Person person = peopleAndPlacesAbstraction.GetPerson(response.Respondent.PartyID.Value, language.LanguageID.Value);
                                if (person != null && person.ErrorsDetected == false && person.PartyID.HasValue)
                                {
                                    person.PersonNames = peopleAndPlacesAbstraction.ListPersonNames(person.PartyID.Value, language.LanguageID.Value);
                                    if (person.PersonNames != null && person.PersonNames.Length == 1 && person.PersonNames[0].ErrorsDetected == false && person.PersonNames[0].PersonNameID.HasValue)
                                    {
                                        Octavo.Gate.Nabu.CORE.Encryption.EncryptorDecryptor encryptorDecryptor = new Encryption.EncryptorDecryptor();
                                        candidateName = encryptorDecryptor.Decrypt(person.PersonNames[0].FullName);
                                    }
                                }


                                string internalFacingOutputFolder = _config.GetValue<string>("Certificate:InternalFacingOutputFolder");
                                string externalFacingOutputFolder = _config.GetValue<string>("Certificate:ExternalFacingOutputFolder");

                                if (internalFacingOutputFolder.EndsWith("\\") == false)
                                    internalFacingOutputFolder += "\\";
                                if (externalFacingOutputFolder.EndsWith("/") == false)
                                    externalFacingOutputFolder += "/";

                                Octavo.Gate.Nabu.CORE.Certificate.Renderer certificateRenderer = new Octavo.Gate.Nabu.CORE.Certificate.Renderer(new Octavo.Gate.Nabu.CORE.Certificate.Configuration.CertificateLayout(_config.GetValue<string>("Certificate:CertificateLayout")));

                                // List Assessment Responses
                                string sqlListAssessmentResponseOutcomes = "SELECT";
                                sqlListAssessmentResponseOutcomes += " air.AssessmentInstrumentResponseID,";
                                sqlListAssessmentResponseOutcomes += " p.PartCode,";
                                sqlListAssessmentResponseOutcomes += " ai.EntityAttributesXML,";
                                sqlListAssessmentResponseOutcomes += " ro.NumericalOutcome,";
                                sqlListAssessmentResponseOutcomes += " air.Ended";
                                sqlListAssessmentResponseOutcomes += " FROM [SchResponse].[AssessmentInstrumentResponse] air";
                                sqlListAssessmentResponseOutcomes += " INNER JOIN[SchResponse].[Response] r ON r.ResponseID = air.AssessmentInstrumentResponseID";
                                sqlListAssessmentResponseOutcomes += " INNER JOIN[SchResponse].[ResponseOutcome] ro ON ro.ResponseID = r.ResponseID";
                                sqlListAssessmentResponseOutcomes += " INNER JOIN[SchResponse].[Respondent] res ON res.RespondentID = r.RespondentID";
                                sqlListAssessmentResponseOutcomes += " INNER JOIN[SchEducation].[AssessmentInstrument] ai ON ai.AssessmentInstrumentID = air.AssessmentInstrumentID";
                                sqlListAssessmentResponseOutcomes += " INNER JOIN[SchCore].[Instrument] i ON i.InstrumentID = ai.InstrumentID";
                                sqlListAssessmentResponseOutcomes += " INNER JOIN[SchOperations].[Part] p ON p.PartID = i.InstrumentID";
                                sqlListAssessmentResponseOutcomes += " WHERE r.ResponseID = " + pResponseID;

                                BaseString[] recordSet = responseAbstraction.CustomQuery(sqlListAssessmentResponseOutcomes);
                                if (recordSet != null && recordSet.Length > 0)
                                {
                                    if (recordSet[0].ErrorsDetected == false)
                                    {
                                        string[] fields = recordSet[0].GetFields();
                                        int assessmentInstrumentResponseID = Convert.ToInt32(fields[0]);
                                        Entities.Operations.Part part = operationsAbstraction.GetPartByCode(fields[1].Replace("'", ""),language.LanguageID.Value);
                                        if (part != null && part.ErrorsDetected == false && part.PartID.HasValue)
                                        {
                                            string instrumentTitle = part.Detail.Name;
                                            Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttributeCollection attributes = new Octavo.Gate.Nabu.CORE.Entities.Utility.EntityAttributeCollection(fields[2].Replace("'", ""));
                                            double numericalOutcome = Convert.ToDouble(fields[3]);
                                            DateTime ended = DateTime.ParseExact(fields[4].Replace("'", ""), "dd-MMM-yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

                                            string filename = candidateName.Replace("'", "").Replace("`", "").Replace("’", "").Replace(" ", "_");
                                            string fileNameSuffix = "_" + part.PartCode.Trim();

                                            string scoreAsPercentage = certificateRenderer.GetDisplayScore(numericalOutcome, attributes);
                                            string passMark = certificateRenderer.GetPassMarkPercentage(attributes);

                                            string testScore = numericalOutcome.ToString() + " out of " + certificateRenderer.GetMaximumMark(attributes) + " (" + scoreAsPercentage.ToString() + "%)";

                                            string testResult = "";
                                            if (Convert.ToDouble(scoreAsPercentage) < Convert.ToDouble(passMark))
                                            {
                                                testResult = "FAILED";
                                            }
                                            else
                                            {
                                                testResult = "PASSED";
                                            }

                                            if (System.IO.File.Exists(internalFacingOutputFolder + filename + fileNameSuffix + ".png"))
                                                System.IO.File.Delete(internalFacingOutputFolder + filename + fileNameSuffix + ".png");

                                            certificateRenderer.data.Add(new KeyValuePair<string, string>("_textCandidateName", candidateName));
                                            certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestName", instrumentTitle));
                                            certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestCompletedAt", ended.ToString("dd-MMM-yyyy HH:mm:ss")));
                                            certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestScore", testScore));
                                            certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestResult", testResult));

                                            certificateRenderer.Render(internalFacingOutputFolder + filename + fileNameSuffix + ".png");

                                            certificateURL.Value = externalFacingOutputFolder + filename + fileNameSuffix + ".png";
                                        }
                                        else
                                        {
                                            certificateURL.ErrorsDetected = true;
                                            certificateURL.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Unable to load Part"));
                                        }
                                    }
                                }
                                recordSet = null;

                                if (certificateURL.Value.Length == 0)
                                {
                                    // List Learning Responses
                                    string sqlListLearningResponseOutcomes = "SELECT";
                                    sqlListLearningResponseOutcomes += " lir.LearningInstrumentResponseID,";
                                    sqlListLearningResponseOutcomes += " p.PartCode,";
                                    sqlListLearningResponseOutcomes += " li.EntityAttributesXML,";
                                    sqlListLearningResponseOutcomes += " lir.Ended,";
                                    sqlListLearningResponseOutcomes += " lir.State";
                                    sqlListLearningResponseOutcomes += " FROM [SchResponse].[LearningInstrumentResponse] lir";
                                    sqlListLearningResponseOutcomes += " INNER JOIN[SchResponse].[Response] r ON r.ResponseID = lir.LearningInstrumentResponseID";
                                    sqlListLearningResponseOutcomes += " INNER JOIN[SchResponse].[Respondent] res ON res.RespondentID = r.RespondentID";
                                    sqlListLearningResponseOutcomes += " INNER JOIN[SchEducation].[LearningInstrument] li ON li.LearningInstrumentID = lir.LearningInstrumentID";
                                    sqlListLearningResponseOutcomes += " INNER JOIN[SchCore].[Instrument] i ON i.InstrumentID = li.InstrumentID";
                                    sqlListLearningResponseOutcomes += " INNER JOIN[SchOperations].[Part] p ON p.PartID = i.InstrumentID";
                                    sqlListLearningResponseOutcomes += " WHERE r.ResponseID = " + pResponseID;

                                    recordSet = responseAbstraction.CustomQuery(sqlListLearningResponseOutcomes);
                                    if (recordSet != null && recordSet.Length > 0)
                                    {
                                        if (recordSet[0].ErrorsDetected == false)
                                        {
                                            string[] fields = recordSet[0].GetFields();
                                            int learningInstrumentResponseID = Convert.ToInt32(fields[0]);
                                            Entities.Operations.Part part = operationsAbstraction.GetPartByCode(fields[1].Replace("'", ""), language.LanguageID.Value);
                                            if (part != null && part.ErrorsDetected == false && part.PartID.HasValue)
                                            {
                                                string instrumentTitle = part.Detail.Name;
                                                DateTime ended = DateTime.ParseExact(fields[3].Replace("'", ""), "dd-MMM-yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);

                                                string filename = candidateName.Replace("'", "").Replace("`", "").Replace("’", "").Replace(" ", "_");
                                                string fileNameSuffix = "_" + part.PartCode.Trim();

                                                string testScore = "";

                                                string testResult = ((fields[4].Replace("'", "").CompareTo("Course Complete") == 0) ? "Complete" : "Incomplete");

                                                if (System.IO.File.Exists(internalFacingOutputFolder + filename + fileNameSuffix + ".png"))
                                                    System.IO.File.Delete(internalFacingOutputFolder + filename + fileNameSuffix + ".png");

                                                certificateRenderer.data.Add(new KeyValuePair<string, string>("_textCandidateName", candidateName));
                                                certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestName", instrumentTitle));
                                                certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestCompletedAt", ended.ToString("dd-MMM-yyyy HH:mm:ss")));
                                                certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestScore", testScore));
                                                certificateRenderer.data.Add(new KeyValuePair<string, string>("_textTestResult", testResult));

                                                certificateRenderer.Render(internalFacingOutputFolder + filename + fileNameSuffix + ".png");

                                                certificateURL.Value = externalFacingOutputFolder + filename + fileNameSuffix + ".png";
                                            }
                                            else
                                            {
                                                certificateURL.ErrorsDetected = true;
                                                certificateURL.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Unable to load Part"));
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                certificateURL.ErrorsDetected = true;
                                certificateURL.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Unable to load Response"));
                            }
                        }
                        else
                        {
                            certificateURL.ErrorsDetected = true;
                            certificateURL.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Unable to load Language"));
                        }
                    }
                    catch (Exception exc)
                    {
                        certificateURL.ErrorsDetected = true;
                        certificateURL.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, exc.Message));
                        certificateURL.StackTrace = exc.StackTrace;
                    }
                    return Ok(certificateURL);
                }
                else
                {
                    apiAccess.AuditAccess(_config.GetValue<string>("APIKeyConfig:AuditFolder"), release.Component, method.Name, state.ToString(), Helper.APICallerInfo.GetIPAddress(HttpContext), Helper.APICallerInfo.GetUserAgent(Request));

                    certificateURL.ErrorsDetected = true;
                    certificateURL.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, state.ToString()));
                    return Unauthorized(certificateURL);
                }
            }
            else
            {
                certificateURL.ErrorsDetected = true;
                certificateURL.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "Missing APIKey/APILicensedTo within Header"));
                return Unauthorized(certificateURL);
            }
        }
    }
}
