#region Usings

using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using SC.YesMailAdapter.Configuration;
using System;
using SC.YesMailAdapter.Http;
using SC.YesMailAdapter.Mappers;
using log4net;
using System.Xml;
using System.Text;

#endregion

namespace SC.YesMailAdapter
{
    public class Emailer
    {

        public static ILog _logger = LogManager.GetLogger(typeof (Emailer));
        private ApiSettings _settings;
        public Emailer()
        {
            
        }

        public Emailer(ApiSettings settings)
        {
            // TODO: Complete member initialization
            this._settings = settings;
        }
        
        /// <returns>Check Status Url</returns>
        public string MakeRequest(string requestBody)
        {
            _logger.Info("\n\nEmail RequestBody\n----------\n" + requestBody);
            var requestCommand = new HttpRequestCommand(_settings);
            var response = requestCommand.ExecutePost(requestBody);
            return response;
        }

        private string ParseResponseForStatusUrl(string response)
        {
            return "test";
        }

        public statusType CheckStatus(string url)
        {
            _logger.Info("\n\nCheck Email Status Url\n----------\n" + url);
            var requestExecutor = new HttpRequestCommand();
            var response = requestExecutor.ExecuteGet(url);
            var status = YesMailSerializer.DeserializeStatus(response);
            return status;
        }

        

        public statusType SendEmail(subscribeAndSend subscribeAndSend)
        {
            try
            {
                var requestBody = YesMailSerializer.Serialize(subscribeAndSend);

                var response = MakeRequest(requestBody);
                _logger.Debug("\n\nResponse: \n-----------\n" + response);
                var status = YesMailSerializer.DeserializeStatus(response);
                return status;
            }
            catch (Exception e)
            {
                _logger.Error("\n\nSendEmail Error\n---------------", e);
                throw;
            }
        }




        


    }
}