using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Response
{
    public class AssessmentInstrumentResponse : BaseSDK
    {
        public AssessmentInstrumentResponse(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Response/AssessmentInstrumentResponse/Version");
        }
        public Entities.Response.AssessmentInstrumentResponse[] List(int pRespondentID)
        {
            BaseString httpResponse = base.HttpGet("Response/AssessmentInstrumentResponse/List/" + pRespondentID);
            if (httpResponse.ErrorsDetected == false)
            {
                return JsonConvert.DeserializeObject<Entities.Response.AssessmentInstrumentResponse[]>(httpResponse.Value);
            }
            else
            {
                List<Entities.Response.AssessmentInstrumentResponse> errors = new List<Entities.Response.AssessmentInstrumentResponse>();
                Entities.Response.AssessmentInstrumentResponse error = new Entities.Response.AssessmentInstrumentResponse();
                if (httpResponse.ErrorCode != null && httpResponse.ErrorCode.ErrorCodeID.HasValue)
                {
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, "HTTP [" + httpResponse.ErrorCode.ErrorCodeID + "]"));
                }
                else
                {
                    error.ErrorsDetected = true;
                    error.ErrorDetails.Add(httpResponse.ErrorDetails[0]);
                    error.StackTrace = httpResponse.StackTrace;
                }
                errors.Add(error);
                return errors.ToArray();
            }
        }
    }
}
