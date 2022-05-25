using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Education
{
    public class LearningInstrument : BaseSDK
    {
        public LearningInstrument(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Education/LearningInstrument/Version");
        }
        public Entities.Education.LearningInstrument Get(int pAssessmentInstrumentID, int pLanguageID)
        {
            BaseString httpResponse = base.HttpGet("Education/LearningInstrument/Get/" + pLanguageID + "/" + pAssessmentInstrumentID);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Education.LearningInstrument>(httpResponse.Value);
            else
            {
                Entities.Education.LearningInstrument error = new Entities.Education.LearningInstrument();
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
