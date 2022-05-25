using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Authentication
{
    public class AuthenticationToken : BaseSDK
    {
        public AuthenticationToken(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Authentication/AuthenticationToken/Version");
        }
        public Entities.Authentication.AuthenticationToken GetByToken(string pAuthenticationToken, int pLanguageID)
        {
            BaseString httpResponse = base.HttpPostJson("Authentication/AuthenticationToken/GetByToken/" + pLanguageID, new BaseString(pAuthenticationToken));
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Authentication.AuthenticationToken>(httpResponse.Value);
            else
            {
                Entities.Authentication.AuthenticationToken error = new Entities.Authentication.AuthenticationToken();
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
        public Entities.Authentication.AuthenticationToken Get(int pAuthenticationTokenID, int pLanguageID)
        {
            BaseString httpResponse = base.HttpGet("Authentication/AuthenticationToken/Get/" + pLanguageID + "/" + pAuthenticationTokenID);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Authentication.AuthenticationToken>(httpResponse.Value);
            else
            {
                Entities.Authentication.AuthenticationToken error = new Entities.Authentication.AuthenticationToken();
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
