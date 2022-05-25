using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Response
{
    public class LearningInstrumentResponse : BaseSDK
    {
        public LearningInstrumentResponse(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Response/LearningInstrumentResponse/Version");
        }
        public Entities.Response.LearningInstrumentResponse[] List(int pRespondentID)
        {
            BaseString httpResponse = base.HttpGet("Response/LearningInstrumentResponse/List/" + pRespondentID);
            if (httpResponse.ErrorsDetected == false)
            {
                return JsonConvert.DeserializeObject<Entities.Response.LearningInstrumentResponse[]>(httpResponse.Value);
            }
            else
            {
                List<Entities.Response.LearningInstrumentResponse> errors = new List<Entities.Response.LearningInstrumentResponse>();
                Entities.Response.LearningInstrumentResponse error = new Entities.Response.LearningInstrumentResponse();
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
