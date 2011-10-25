#region Usings

using System.Collections.Specialized;
using System.Net;
using System.Text;
using SC.YesMailAdapter.Configuration;
using log4net;

#endregion

namespace SC.YesMailAdapter.Http
{
    public class HttpRequestExecutor
    {
        #region -- Members and Constructors -- 
        
        public static ILog _logger = LogManager.GetLogger(typeof (Emailer));
        private readonly ApiSettings _apiSettings;

        public HttpRequestExecutor() : this(new ApiSettings())
        {
        }

        public HttpRequestExecutor(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        #endregion //-- Members and Constructors --

        public string ExecutePost(string messageBody)
        {
            var webRequest = RequestHelper.CreateWebRequest(_apiSettings.Url, "POST", "application/xml");
            if (_apiSettings.UseProxy)
            {
                SetProxy(webRequest);
            }

            var headers = GetHeaders();
            RequestHelper.SetHeaders(headers, webRequest);

            RequestHelper.SetCredentialCache(webRequest, _apiSettings.Url, _apiSettings.Domain, _apiSettings.UserName, _apiSettings.Password);
            
            LogRequest(webRequest);
            var rtnValue = RequestHelper.GetResponse(webRequest, messageBody);
            return rtnValue;
        }

        public string ExecuteGet(string url)
        {
            var webRequest = RequestHelper.CreateWebRequest(url, "GET", "application/xml");
            if (_apiSettings.UseProxy)
            {
                SetProxy(webRequest);
            }

            var headers = GetHeaders();
            RequestHelper.SetHeaders(headers, webRequest);

            RequestHelper.SetCredentialCache(webRequest, _apiSettings.Url, _apiSettings.Domain, _apiSettings.UserName, _apiSettings.Password);

            LogRequest(webRequest);
            var rtnValue = RequestHelper.GetResponse(webRequest);
            return rtnValue;
        }

        private void SetProxy(HttpWebRequest webRequest)
        {
            var proxySettings = _apiSettings.ProxySettings;
            webRequest.Proxy = new WebProxy(proxySettings.Url, proxySettings.Port);
            webRequest.Proxy.Credentials = new NetworkCredential(proxySettings.UserName,
                                                                 proxySettings.Password);
        }

        private NameValueCollection GetHeaders()
        {
            //Set Authorization ID
            var userCreds = _apiSettings.Domain + '/' + _apiSettings.UserName + ':' + _apiSettings.Password;
            var authorizationId = "Basic " + RequestHelper.EncodeTo64(userCreds);
            var headers = new NameValueCollection {{@"Authorization", authorizationId}};
            return headers;
        }

        private void LogRequest(HttpWebRequest request)
        {
            var sb = new StringBuilder();

            sb.Append("\n\nRequestInfo\n----------\n")
                .Append("Host: ").Append(request.Host).Append("\n")
                .Append("Url: ").Append(request.RequestUri).Append("\n")
                .Append("\nHeaders \n-------\n").Append(request.Headers.ToString()).Append("\n");


            _logger.Debug(sb.ToString());
        }
    }
}