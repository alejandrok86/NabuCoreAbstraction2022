using Newtonsoft.Json;
using Octavo.Gate.Nabu.CORE.Entities;
using RestSharp;
using System;

namespace Octavo.Gate.Nabu.CORE.API.SDK
{
    public class BaseSDK
    {
        private string APIRootUrl { get; set; } = "";
        private string APIKey { get; set; } = "";
        private string APILicensedTo { get; set; } = "";

        public BaseSDK(string pAPIRootUrl, string pAPIKey, string pAPILicensedTo)
        {
            APIRootUrl = pAPIRootUrl;
            APIKey = pAPIKey;
            APILicensedTo = pAPILicensedTo;
        }

        public BaseString HttpGet(string pMethod)
        {
            BaseString result = new BaseString();
            try
            {
                var client = new RestClient(APIRootUrl);
                var request = new RestRequest(pMethod, DataFormat.Json);
                request.AddHeader("APIKey", APIKey);
                request.AddHeader("APILicensedTo", APILicensedTo);
                var response = client.Get(request);
                result.ErrorCode = new Entities.Error.ErrorCode(Convert.ToInt32(response.StatusCode));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Value = response.Content;
                }
                else
                {
                    if (response.ResponseStatus == ResponseStatus.Error)
                    {
                        result.ErrorsDetected = true;
                        result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, response.ErrorMessage));
                    }
                    else
                    {
                        result.ErrorCode = new Entities.Error.ErrorCode(Convert.ToInt32(response.StatusCode));
                        result.ErrorsDetected = true;
                    }
                }
                }
            catch (Exception exc)
            {
                result.ErrorsDetected = true;
                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1,exc.Message));
                result.StackTrace = exc.StackTrace;
            }
            return result;
        }
        public BaseVersion HttpGetVersion(string pMethod)
        {
            BaseVersion version = new BaseVersion();
            try
            {
                var client = new RestClient(APIRootUrl);
                var request = new RestRequest(pMethod, DataFormat.Json);
                request.AddHeader("APIKey", APIKey);
                request.AddHeader("APILicensedTo", APILicensedTo);
                var response = client.Get(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    version = JsonConvert.DeserializeObject<BaseVersion>(response.Content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    version = JsonConvert.DeserializeObject<BaseVersion>(response.Content);
                }
                else
                {
                    if (response.ResponseStatus == ResponseStatus.Error)
                    {
                        version.ErrorsDetected = true;
                        version.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, response.ErrorMessage));
                    }
                    else
                    {
                        version.ErrorsDetected = true;
                        version.ErrorCode = new Entities.Error.ErrorCode(Convert.ToInt32(response.StatusCode));
                    }
                }
            }
            catch (Exception exc)
            {
                version.ErrorsDetected = true;
                version.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, exc.Message));
                version.StackTrace = exc.StackTrace;
            }
            return version;
        }
        public BaseString HttpGetString(string pMethod)
        {
            BaseString result = new BaseString();
            try
            {
                var client = new RestClient(APIRootUrl);
                var request = new RestRequest(pMethod, DataFormat.Json);
                request.AddHeader("APIKey", APIKey);
                request.AddHeader("APILicensedTo", APILicensedTo);
                var response = client.Get(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<BaseString>(response.Content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    result = JsonConvert.DeserializeObject<BaseString>(response.Content);
                }
                else
                {
                    if (response.ResponseStatus == ResponseStatus.Error)
                    {
                        result.ErrorsDetected = true;
                        result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, response.ErrorMessage));
                    }
                    else
                    {
                        result.ErrorsDetected = true;
                        result.ErrorCode = new Entities.Error.ErrorCode(Convert.ToInt32(response.StatusCode));
                    }
                }
            }
            catch (Exception exc)
            {
                result.ErrorsDetected = true;
                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, exc.Message));
                result.StackTrace = exc.StackTrace;
            }
            return result;
        }

        public BaseString HttpPostJson(string pMethod, object pObject)
        {
            BaseString result = new BaseString();
            try
            {
                var client = new RestClient(APIRootUrl);
                var request = new RestRequest(pMethod, DataFormat.Json);
                request.AddHeader("APIKey", APIKey);
                request.AddHeader("APILicensedTo", APILicensedTo);
                request.AddJsonBody(pObject);
                var response = client.Post(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Value = response.Content;
                }
                else
                {
                    if (response.ResponseStatus == ResponseStatus.Error)
                    {
                        result.ErrorsDetected = true;
                        result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, response.ErrorMessage));
                    }
                    else
                    {
                        result.ErrorsDetected = true;
                        result.ErrorCode = new Entities.Error.ErrorCode(Convert.ToInt32(response.StatusCode));
                    }
                }
            }
            catch (Exception exc)
            {
                result.ErrorsDetected = true;
                result.ErrorDetails.Add(new Entities.Error.ErrorDetail(-1, exc.Message));
                result.StackTrace = exc.StackTrace;
            }
            return result;
        }
    }
}
