namespace Octavo.Gate.Nabu.CORE.API.Helper
{
    public class APICallerInfo
    {
        public static string GetIPAddress(Microsoft.AspNetCore.Http.HttpContext pHttpContext)
        {
            string IP = "";
            try
            {
                IP = pHttpContext.Connection.RemoteIpAddress.ToString();
                /*var props = OperationContext.Current.IncomingMessageProperties;
                var endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                if (endpointProperty != null)
                {
                    if (endpointProperty.Address == "::1" || String.IsNullOrEmpty(endpointProperty.Address))
                        IP = "127.0.0.1";
                    else
                        IP = endpointProperty.Address;
                }*/
                if (IP.CompareTo("::1")==0)
                    IP = "127.0.0.1";
            }
            catch
            {
            }
            return IP;
        }

        public static string GetUserAgent(Microsoft.AspNetCore.Http.HttpRequest pHttpRequest)
        {
            string userAgent = "";
            try
            {
                if (pHttpRequest.Headers.ContainsKey("User-Agent"))
                    userAgent = pHttpRequest.Headers["User-Agent"];

                /*OperationContext context = OperationContext.Current;
                if (context != null)
                {
                    MessageProperties messageProperties = context.IncomingMessageProperties;
                    if (messageProperties["httpRequest"] != null)
                    {
                        HttpRequestMessageProperty httpRequest = messageProperties["httpRequest"] as HttpRequestMessageProperty;
                        if (httpRequest != null)
                        {
                            userAgent = httpRequest.Headers["User-Agent"];
                        }
                    }
                    //if(messageProperties["Via"] != null)
                    //{
                    //    var via = messageProperties["Via"];
                    //}
                    //if (messageProperties["UriTemplateMatchResults"] != null)
                    //{
                    //    var uriTemplateMatchResults = messageProperties["UriTemplateMatchResults"];
                    //}
                    //if (messageProperties["UriMatched"] != null)
                    //{
                    //    var uriMatched = messageProperties["UriMatched"];
                    //}
                    //if (messageProperties["HttpOperationName"] != null)
                    //{
                    //    var httpOperationName = messageProperties["HttpOperationName"];
                    //}
                }*/
            }
            catch
            {
            }
            return userAgent;
        }
    }
}
