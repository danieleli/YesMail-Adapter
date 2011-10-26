#region Usings

using System;
using SC.YesMailAdapter;
using SC.YesMailAdapter.Attributes;

#endregion

namespace SC.YesmailAdapter._Test.Helpers
{
    public class MessageHistory : IMessageDto
    {
        public string MessageDescription { get; set; }
        public string MessageGuid { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Status { get; set; }

        #region IMessageDto Members

        public string MasterMessageId { get; set; }
        public string ConsumerId { get; set; }
        public string Email { get; set; }

        #endregion
    }

    public class TestMessageDto : IMessageDto
    {
        //[SideTableTolken(TableName = "api_transactions")]
        public string Brand { get; set; }
        //[SideTableTolken(TableName = "api_transactions")]
        public string MasterMessageId { get; set; }
        // [SideTableTolken(TableName = "api_transactions")]
        //public string TransactionType { get; set; }

        [SubscriberTolken]
        public string ConsumerId { get; set; }
        
        [SubscriberTolken]
        [SideTableTolken(TableName = "API_PROMOS")]
        public string Email { get; set; }

        public string ExpirationDate { get; set; }

        [SideTableTolken(TableName = "API_PROMOS")]
        public string Generic1 { get; set; }

        [SideTableTolken(TableName = "API_PROMOS")]
        public string Generic2 { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string Generic3 { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string Name1 { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string Name2 { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string ProductDescription { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string RedemptionCode { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string SecurityCode { get; set; }

        [SideTableTolken(TableName = "API_PROMOS")]
        public string Url1 { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string Url2 { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string Url3 { get; set; }
        [SideTableTolken(TableName = "API_PROMOS")]
        public string Type { get; set; }
    }
}