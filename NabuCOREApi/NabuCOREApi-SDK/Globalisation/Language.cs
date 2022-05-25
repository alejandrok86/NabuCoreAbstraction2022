using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Globalisation
{
    public class Language : BaseSDK
    {
        public Language(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Globalisation/Language/Version");
        }
        public Entities.Globalisation.Language GetLanguageBySystemName(string pSystemName)
        {
            BaseString httpResponse = base.HttpGet("Globalisation/Language/GetBySystemName/" + pSystemName);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Globalisation.Language>(httpResponse.Value);
            else
            {
                Entities.Globalisation.Language error = new Entities.Globalisation.Language();
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
        public Entities.Globalisation.Language[] ListLanguages()
        {
            BaseString httpResponse = base.HttpGet("Globalisation/Language/List");
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Globalisation.Language[]>(httpResponse.Value);
            else
            {
                List<Entities.Globalisation.Language> errors = new List<Entities.Globalisation.Language>();
                Entities.Globalisation.Language error = new Entities.Globalisation.Language();
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
