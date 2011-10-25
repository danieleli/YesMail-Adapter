#region Usings

using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using SC.YesMailAdapter.Configuration;
using SC.YesMailAdapter.Factory;
using System;
using SC.YesMailAdapter.Http;
using log4net;

#endregion

namespace SC.YesMailAdapter
{
    public class Emailer
    {

        public static ILog _logger = LogManager.GetLogger(typeof (Emailer));
        public Emailer()
        {
            
        }
        
        /// <returns>Check Status Url</returns>
        public string MakeRequest(string requestBody)
        {
            _logger.Info("\n\nEmail RequestBody\n----------\n" + requestBody);
            var requestExecutor = new HttpRequestExecutor();
            var response = requestExecutor.ExecutePost(requestBody);
            return response;
        }

        public string CheckStatus(string url)
        {
            _logger.Info("\n\nCheck Email Status Url\n----------\n" + url);
            var requestExecutor = new HttpRequestExecutor();
            var response = requestExecutor.ExecuteGet(url);
            return response;
        }

        

        public string SendEmail(subscribeAndSend subscribeAndSend)
        {
            try
            {
                var requestBody = YesMailSerializer.CreateRequestBody(subscribeAndSend);
                _logger.Info("\n\nEmail RequestBody\n----------\n" + requestBody);
                
                var httpHelper = new HttpRequestExecutor();
                var response = httpHelper.ExecutePost(requestBody);
                _logger.Debug("\n\nResponse: \n-----------\n" + response);
                
                return response;
            }
            catch (Exception e)
            {
                _logger.Error("\n\nSendEmail Error\n---------------", e);
                throw;
            }
        }




        


    }
}