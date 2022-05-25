using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.API.SDK.NabuProducts
{
    public class Certify : BaseSDK
    {
        public Certify(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo) : base(pAPIRootUrl, pAPIKey, pAPILicensedTo)
        {
        }

        public BaseVersion GetVersion()
        {
            return base.HttpGetVersion("NabuProducts/Certify/Version");
        }
        public Octavo.Gate.Nabu.CORE.API.Helper.RecordSet ListActiveAssessmentInstruments()
        {
            BaseString httpResponse = base.HttpGet("NabuProducts/Certify/ListActiveAssessmentInstruments");
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Octavo.Gate.Nabu.CORE.API.Helper.RecordSet>(httpResponse.Value);
            else
            {
                Octavo.Gate.Nabu.CORE.API.Helper.RecordSet error = new Octavo.Gate.Nabu.CORE.API.Helper.RecordSet();
                if (httpResponse.ErrorCode != null && httpResponse.ErrorCode.ErrorCodeID.HasValue)
                {
                    error.hasErrors = true;
                    error.errorMessage = "HTTP [" + httpResponse.ErrorCode.ErrorCodeID + "]";
                }
                else
                {
                    error.hasErrors = true;
                    error.errorMessage = httpResponse.ErrorDetails[0].ErrorMessage;
                }
                return error;
            }
        }
        public Octavo.Gate.Nabu.CORE.API.Helper.RecordSet ListActiveLearningInstruments()
        {
            BaseString httpResponse = base.HttpGet("NabuProducts/Certify/ListActiveLearningInstruments");
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Octavo.Gate.Nabu.CORE.API.Helper.RecordSet>(httpResponse.Value);
            else
            {
                Octavo.Gate.Nabu.CORE.API.Helper.RecordSet error = new Octavo.Gate.Nabu.CORE.API.Helper.RecordSet();
                if (httpResponse.ErrorCode != null && httpResponse.ErrorCode.ErrorCodeID.HasValue)
                {
                    error.hasErrors = true;
                    error.errorMessage = "HTTP [" + httpResponse.ErrorCode.ErrorCodeID + "]";
                }
                else
                {
                    error.hasErrors = true;
                    error.errorMessage = httpResponse.ErrorDetails[0].ErrorMessage;
                }
                return error;
            }
        }
        public Octavo.Gate.Nabu.CORE.API.Helper.RecordSet ListActiveInstruments()
        {
            BaseString httpResponse = base.HttpGet("NabuProducts/Certify/ListActiveInstruments");
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Octavo.Gate.Nabu.CORE.API.Helper.RecordSet>(httpResponse.Value);
            else
            {
                Octavo.Gate.Nabu.CORE.API.Helper.RecordSet error = new Octavo.Gate.Nabu.CORE.API.Helper.RecordSet();
                if (httpResponse.ErrorCode != null && httpResponse.ErrorCode.ErrorCodeID.HasValue)
                {
                    error.hasErrors = true;
                    error.errorMessage = "HTTP [" + httpResponse.ErrorCode.ErrorCodeID + "]";
                }
                else
                {
                    error.hasErrors = true;
                    error.errorMessage = httpResponse.ErrorDetails[0].ErrorMessage;
                }
                return error;
            }
        }
        public Octavo.Gate.Nabu.CORE.API.Helper.RecordSet ListInstrumentProgress(string pAuthenticationToken)
        {
            BaseString httpResponse = base.HttpPostJson("NabuProducts/Certify/ListInstrumentProgress", new BaseString(pAuthenticationToken));
            if (httpResponse.ErrorsDetected == false)
                return JsonConvert.DeserializeObject<Octavo.Gate.Nabu.CORE.API.Helper.RecordSet>(httpResponse.Value);
            else
            {
                Octavo.Gate.Nabu.CORE.API.Helper.RecordSet error = new Octavo.Gate.Nabu.CORE.API.Helper.RecordSet();
                if (httpResponse.ErrorCode != null && httpResponse.ErrorCode.ErrorCodeID.HasValue)
                {
                    error.hasErrors = true;
                    error.errorMessage = "HTTP [" + httpResponse.ErrorCode.ErrorCodeID + "]";
                }
                else
                {
                    error.hasErrors = true;
                    error.errorMessage = httpResponse.ErrorDetails[0].ErrorMessage;
                }
                return error;
            }
        }

        public BaseString GetPNGCertificate(int pResponseID)
        {
            return base.HttpGetString("NabuProducts/Certify/GetPNGCertificate/" + pResponseID);
        }
    }
}
