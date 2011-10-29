#region Usings

using System;
using SC.YesMailAdapter.Configuration;
using SC.YesMailAdapter.Http;
using SC.YesMailAdapter.Mappers;
using log4net;

#endregion

namespace SC.YesMailAdapter
{
    public class YesmailService
    {
        public static ILog _logger = LogManager.GetLogger(typeof (YesmailService));
        private readonly ApiSettings _settings;

        public YesmailService()
        {
        }

        public YesmailService(ApiSettings settings)
        {
            _settings = settings;
        }

        public statusType SendEmail(object dto, int messageId)
        {
            var sendAndSubscribe = YesMailMapper.CreateSendAndSubcribeMessage(dto, messageId);
            var status = SendEmail(sendAndSubscribe);
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

        public statusType CheckStatus(string url)
        {
            var requestExecutor = CreateRequestCommand();
            var response = requestExecutor.ExecuteGet(url);
            var status = YesMailSerializer.DeserializeStatus(response);
            return status;
        }

        private HttpRequestCommand CreateRequestCommand()
        {
            return new HttpRequestCommand(_settings);
        }


        /// <returns>Check Status Url</returns>
        private string MakeRequest(string requestBody)
        {
            var requestCommand = CreateRequestCommand();
            var response = requestCommand.ExecutePost(requestBody);
            return response;
        }
    }
}