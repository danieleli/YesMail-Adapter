using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SC.YesMailAdapter.Attributes;
using SC.YesMailAdapter;

namespace SC.YesmailAdapter._Test
{


    public class MessageHistory : IMessageDto
    {
        public string MasterMessageId { get; set; }
        public string MessageDescription { get; set; }
        public string ConsumerId { get; set; }
        public string Email { get; set; }
        public string MessageGuid { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Status { get; set; }
    }

    public class TestMessageDto : IMessageDto
    {
        public string MasterMessageId { get; set; }
        public string ConsumerId { get; set; }
        public string Email { get; set; }
        public string ExpirationDate { get; set; }
        [SubscriberTolken]
        public string Generic1 { get; set; }
        [SideTableTolken(TableName = "api_promos")]
        public string Generic2 { get; set; }
        public string Generic3 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string ProductDescription { get; set; }
        public string RedemptionCode { get; set; }
        public string SecurityCode { get; set; }
        public string MessageType { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
        public string Brand { get; set; }
        
        
    }
}
