using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SC.YesMailAdapter.Configuration;
using log4net;
using System.Collections.Specialized;

namespace SC.YesMailAdapter
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
            
        }
        public ServiceException(string message): base(message)
        {
        }
    }

    public class EmailSender
    {
        #region -- Members and Constructors --

        public static ILog _logger = LogManager.GetLogger(typeof(Emailer));

        #endregion //-- Members and Constructors --

        /// <returns>Returns Message Guid</returns>
        public string SendMail(IEnumerable<Recipient> recipients, MetaMessage message)
        {
            var requestBody = SerializeMessage(recipients, message);
            var response = "";//worker.executeRequest(requestBody)
            var messageGuid = ParseMessageGuidFromResponse(response);
            var status = StatusChecker.GetStatus(messageGuid);
            ParseMessageGuidFromResponse(status);
         
            return messageGuid;
        }

        private object SerializeMessage(IEnumerable<Recipient> recipients, MetaMessage message)
        {
            throw new NotImplementedException();
        }

        public void ThrowExeceptionOnFailure(string status)
        {
            if (status != "OK")
            {
                throw new ServiceException(status);
            }
        }


        private string ParseMessageGuidFromResponse(string response)
        {
            // if not valid
            //throw new ServiceException("Insert Message From response here");
            // else get Guid
            var guid = "xxxx";
            return guid;
        }

    }

    public class StatusChecker
    {
        private readonly const string STATUS_URL = "HTTP://service.yesmail.com/";
        public static string GetStatus(string messageGuid)
        {
            var url = STATUS_URL + messageGuid;
            var response = "";//worker.executeRequest(requestBody)
            return response;
        }
    }

    public class MetaMessage
    {
        public string LastTimeUpdated{ get; set; }
        public int TransactionId{ get; set; }
        public int MasterMailId { get; set; }
        public string MessageType { get; set; }
        public object Tolkens { get; set; }
    }

    public class Tolkens
    {
        public string Email { get; set; }
        public string Name1 { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
        public string Generic1 { get; set; }
        public string Generic2 { get; set; }
        public string Generic3 { get; set; }
        public string Brand { get; set; }
    }



    public class Recipient
    {
        public string Email { get; set; }
        public string ConsumerId { get; set; }
    }
}
