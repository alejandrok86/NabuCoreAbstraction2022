using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Education
{
    public class Specification : BaseSDK
    {
        public Specification(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Education/Specification/Version");
        }
        public Entities.Education.Specification[] ListSpecifications(int pAwardingBodyID,int pLanguageID)
        {
            BaseString httpResponse = base.HttpGet("Education/Specification/List/" + pLanguageID + "/" + pAwardingBodyID);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Education.Specification[]>(httpResponse.Value);
            else
            {
                List<Entities.Education.Specification> errors = new List<Entities.Education.Specification>();
                Entities.Education.Specification error = new Entities.Education.Specification();
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
        public Entities.Content.Content[] ListContent(int pSpecificationID)
        {
            BaseString httpResponse = base.HttpGet("Education/Specification/Content/List/" + pSpecificationID);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Content.Content[]>(httpResponse.Value);
            else
            {
                List<Entities.Content.Content> errors = new List<Entities.Content.Content>();
                Entities.Content.Content error = new Entities.Content.Content();
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
