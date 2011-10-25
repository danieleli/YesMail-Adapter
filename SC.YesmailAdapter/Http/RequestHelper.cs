#region Usings

using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Net;

#endregion

namespace SC.YesMailAdapter.Http
{
    public static class RequestHelper
    {
        public static string GetResponse(HttpWebRequest webRequest, string requestBody)
        {
            string response = null;
            if(!string.IsNullOrEmpty(requestBody))
            {
                WriteRequestBody(ref webRequest, requestBody);    
            }
            
            using (var httpWebResponse = (HttpWebResponse) webRequest.GetResponse())
            {
                var encoding = Encoding.GetEncoding(1252); //1252 for Windows operating system (windows-1252);
                using (var reader = new StreamReader(httpWebResponse.GetResponseStream(), encoding))
                {
                    response = reader.ReadToEnd();
                    reader.Close();
                }
                httpWebResponse.Close();
            }

            return response;
        }

        public static string GetResponse(HttpWebRequest webRequest)
        {
            string response = GetResponse(webRequest, null);
            return response;
        }

        public static HttpWebRequest CreateWebRequest(string uri, string requestMethod, string contentType)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(uri);
            webRequest.KeepAlive = false;
            webRequest.Method = requestMethod;
            webRequest.ContentType = contentType;
            webRequest.AllowAutoRedirect = false;

            return webRequest;
        }

        public static void SetHeaders(NameValueCollection headers, HttpWebRequest webrequest)
        {
            var iCount = headers.Count;
            string key;
            string keyvalue;

            for (var i = 0; i < iCount; i++)
            {
                key = headers.Keys[i];
                keyvalue = headers[i];
                webrequest.Headers.Add(key, keyvalue);
            }
        }

        public static string EncodeTo64(string toEncode)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            var returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }


        private static void WriteRequestBody(ref HttpWebRequest webrequest, string requestBody)
        {
            var bytes = Encoding.ASCII.GetBytes(requestBody);
            webrequest.ContentLength = bytes.Length;

            using (var oStreamOut = webrequest.GetRequestStream())
            {
                oStreamOut.Write(bytes, 0, bytes.Length);
                oStreamOut.Close();
            }
        }

        //private string GetRedirectURL_NOTUSED(HttpWebResponse webresponse, ref string Cookie)
        //{
        //    var uri = "";

        //    var headers = webresponse.Headers;

        //    if ((webresponse.StatusCode == HttpStatusCode.Found) ||
        //        (webresponse.StatusCode == HttpStatusCode.Redirect) ||
        //        (webresponse.StatusCode == HttpStatusCode.Moved) ||
        //        (webresponse.StatusCode == HttpStatusCode.MovedPermanently))
        //    {
        //        // Get redirected uri
        //        uri = headers["Location"].Trim();
        //    }

        //    //Check for any cookies
        //    if (headers["Set-Cookie"] != null)
        //    {
        //        Cookie = headers["Set-Cookie"];
        //    }

        //    return uri;
        //}
    }
}