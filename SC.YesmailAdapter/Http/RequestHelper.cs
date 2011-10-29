#region Usings

using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

#endregion

namespace SC.YesMailAdapter.Http
{
    public static class RequestHelper
    {
        public static string GetResponse(HttpWebRequest webRequest, string requestBody)
        {
            string response = null;
            if (!string.IsNullOrEmpty(requestBody))
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
            return GetResponse(webRequest, null);
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