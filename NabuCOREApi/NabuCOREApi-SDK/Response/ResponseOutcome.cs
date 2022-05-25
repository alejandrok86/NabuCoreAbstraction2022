using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.API.SDK.Response
{
    public class ResponseOutcome : BaseSDK
    {
        public ResponseOutcome(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("Response/ResponseOutcome/Version");
        }

        public Entities.Response.ResponseOutcome[] List(int pResponseID)
        {
            BaseString httpResponse = base.HttpGet("Response/ResponseOutcome/List/" + pResponseID);
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Entities.Response.ResponseOutcome[]>(httpResponse.Value);
            else
            {
                List<Entities.Response.ResponseOutcome> errors = new List<Entities.Response.ResponseOutcome>();
                Entities.Response.ResponseOutcome error = new Entities.Response.ResponseOutcome();
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
