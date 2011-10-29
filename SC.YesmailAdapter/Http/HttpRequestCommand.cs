#region Usings

using System;
using System.Collections.Specialized;
using System.Text;
using SC.YesMailAdapter.Configuration;
using log4net;
using System.Net;

#endregion

namespace SC.YesMailAdapter.Http
{
    public class HttpRequestCommand
    {
        #region -- fields and constructors --

        public static ILog _logger = LogManager.GetLogger(typeof(YesmailService));
        private readonly ApiSettings _apiSettings;

        public HttpRequestCommand()
            : this(new ApiSettings())
        {
        }

        public HttpRequestCommand(ApiSettings apiSettings)
        {
            if (apiSettings != null)
            {
                _apiSettings = apiSettings;
            }
            else
            {
                _apiSettings = new ApiSettings();
            }

        }

        #endregion -- fields and constructors --

        public string ExecutePost(string messageBody)
        {
            return ExecuteRequest(_apiSettings.Url, "POST");
        }

        public string ExecuteGet(string uri)
        {
            return ExecuteRequest(uri, "GET");
        }

        private string ExecuteRequest(string uri, string httpMethod)
        {
            var webRequest = CreateWebRequest(uri, httpMethod, _apiSettings);
            var rtnString = RequestHelper.GetResponse(webRequest);

            return rtnString;
        }

        private static HttpWebRequest CreateWebRequest(string uri, string httpMethod, ApiSettings settings)
        {
            var webRequest = CreateWebRequest(uri, httpMethod, "application/xml");

            if (settings.UseProxy)
            {
                SetProxy(webRequest, settings.ProxySettings);
            }

            var headers = GetHeaders(settings);
            RequestHelper.SetHeaders(headers, webRequest);

            SetCredentialCache(webRequest, settings.Url, settings.Domain, settings.UserName,
                               settings.Password);

            LogRequest(webRequest);

            return webRequest;
        }

        private static HttpWebRequest CreateWebRequest(string uri, string requestMethod, string contentType)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.KeepAlive = false;
            webRequest.Method = requestMethod;
            webRequest.ContentType = contentType;
            webRequest.AllowAutoRedirect = false;

            return webRequest;
        }

        private static void SetProxy(HttpWebRequest webRequest, ProxySettings proxySettings)
        {
            webRequest.Proxy = new WebProxy(proxySettings.Url, proxySettings.Port);
            webRequest.Proxy.Credentials = new NetworkCredential(proxySettings.UserName,
                                                                 proxySettings.Password);
        }

        private static NameValueCollection GetHeaders(ApiSettings settings)
        {
            //Set Authorization ID
            var userCreds = settings.Domain + '/' + settings.UserName + ':' + settings.Password;
            var authorizationId = "Basic " + EncodeTo64(userCreds);
            var headers = new NameValueCollection { { @"Authorization", authorizationId } };
            return headers;
        }

        private static void SetCredentialCache(HttpWebRequest webrequest, string uri, string apiDomain, string apiUserName, string apiPassword)
        {
            var credentialCache =
                new CredentialCache();
            credentialCache.Add(new Uri(uri), "Basic",
                                new NetworkCredential(apiUserName, apiPassword, apiDomain));
            webrequest.Credentials = credentialCache;
        }

        private static void LogRequest(HttpWebRequest request)
        {
            var sb = new StringBuilder();

            sb.Append("\n\nRequestInfo\n----------\n")
                .Append("Host: ").Append(request.Host).Append("\n")
                .Append("Url: ").Append(request.RequestUri).Append("\n")
                .Append("\nHeaders \n-------\n").Append(request.Headers.ToString()).Append("\n");


            _logger.Debug(sb.ToString());
        }

        public static string EncodeTo64(string toEncode)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            var returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
}