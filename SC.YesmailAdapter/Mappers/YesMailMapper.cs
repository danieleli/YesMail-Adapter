namespace SC.YesMailAdapter.Mappers
{
    public class YesMailMapper
    {
        public static subscribeAndSend CreateSendAndSubcribeMessage(object messageDto, int messageId)
        {
            var message = new subscribeAndSend
                              {
                                  subscriber = CreateSubscriber(messageDto),
                                  subscriberMessage = new subscriberMessage {masterId = messageId},
                                  sideTable = CreateSideTableArray(messageDto)
                              };
            return message;
        }

        private static subscriberBase CreateSubscriber(object messageDto)
        {
            var myAttributes = new attributes
                                   {
                                       attribute = SubcriberTolkenMapper.FlattenPropertiesToNameValueList(messageDto)
                                   };

            var subscriber = new subscriberBase
                                 {
                                     division = new subscriberBaseDivision {Value = "Transactional"},
                                     allowResubscribe = true,
                                     attributes = myAttributes,
                                     subscriptionState = GlobalSubscriptionState.SUBSCRIBED,
                                     subscriptionStateSpecified = true
                                 };

            return subscriber;
        }

        private static sideTableTable[] CreateSideTableArray(object messageDto)
        {
            var sideTable = CreateSideTable(messageDto, "api_promos");

            return new[] {sideTable};
        }

        private static sideTableTable CreateSideTable(object messageDto, string tableName)
        {
            var myRowColumns = new rowColumns
                                   {
                                       column = SideTableTolkenMapper.FlattenPropertiesToNameValueList(messageDto)
                                   };
            var sideTable = new sideTableTable {rows = new[] {new row {columns = myRowColumns}}, name = tableName};
            return sideTable;
        }
    }
}