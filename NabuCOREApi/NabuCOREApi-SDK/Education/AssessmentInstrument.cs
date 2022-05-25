using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Education
{
    public class AssessmentInstrument : BaseSDK
    {
        public AssessmentInstrument(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Education/AssessmentInstrument/Version");
        }
        public Entities.Education.AssessmentInstrument Get(int pAssessmentInstrumentID, int pLanguageID)
        {
            BaseString httpResponse = base.HttpGet("Education/AssessmentInstrument/Get/" + pLanguageID + "/" + pAssessmentInstrumentID);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Education.AssessmentInstrument>(httpResponse.Value);
            else
            {
                Entities.Education.AssessmentInstrument error = new Entities.Education.AssessmentInstrument();
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
                return error;
            }
        }
    }
}
