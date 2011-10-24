#region Usings

using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using SC.YesMailAdapter.Configuration;
using SC.YesMailAdapter.Factory;
using SC.YesMailAdapter.Generated;
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

        public string SendEmail(EmailMessageDto messageDto)
        {
            try
            {
                var sendAndSubcribeMessage = CreateSendAndSubcribeMessage(messageDto);
                
                var requestBody = RequestBodyFactory.CreateRequestBody(sendAndSubcribeMessage);
                _logger.Info("\n\nEmail RequestBody\n----------\n" + requestBody);
                
                var httpHelper = new HttpRequestExecutor();
                var response = httpHelper.ExecuteRequest(requestBody);
                _logger.Debug("\n\nResponse: \n-----------\n" + response);
                
                return response;
            }
            catch (Exception e)
            {
                _logger.Error("\n\nSendEmail Error\n---------------", e);
                throw;
            }
        }


        private static subscribeAndSend CreateSendAndSubcribeMessage(EmailMessageDto messageDto)
        {
            var subscriber = SubscriberFactory.CreateSubscriber(messageDto);
            var message = new subscribeAndSend
                              {
                                  Items = new object[2]
                                              {
                                                  subscriber,
                                                  new subscribeAndSendSubscriberMessage
                                                      {
                                                          masterId = messageDto.MessageMasterId
                                                      }
                                              }
                              };
            return message;
        }

        


    }
}