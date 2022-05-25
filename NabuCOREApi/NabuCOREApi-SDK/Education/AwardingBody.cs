using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Education
{
    public class AwardingBody : BaseSDK
    {
        public AwardingBody(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Education/AwardingBody/Version");
        }
        public Entities.Education.AwardingBody[] ListAwardingBodies(int pLanguageID)
        {
            BaseString httpResponse = base.HttpGet("Education/AwardingBody/List/" + pLanguageID);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Education.AwardingBody[]>(httpResponse.Value);
            else
            {
                List<Entities.Education.AwardingBody> errors = new List<Entities.Education.AwardingBody>();
                Entities.Education.AwardingBody error = new Entities.Education.AwardingBody();
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
