

namespace SC.YesMailAdapter.Mappers
{
    public class YesMailMapper
    {

        public static subscribeAndSend CreateSendAndSubcribeMessage(object messageDto, int messageId)
        {
            bool allowResubscribe = true;
            var division = new subscriberBaseDivision() { Value = "Transactional"};
            var subscriptionState = GlobalSubscriptionState.SUBSCRIBED;

            var subscriber = CreateSubscriber(messageDto, allowResubscribe, division, subscriptionState);
            var sideTable = CreateSideTable(messageDto);
            subscriber.subscriptionStateSpecified = true;
            var message = new subscribeAndSend
            {
                subscriber = subscriber,
                subscriberMessage = new subscriberMessage() { masterId = messageId },
                sideTable = new sideTableTable[]{ sideTable }
            };
            return message;
        }

        private static sideTableTable CreateSideTable(object messageDto)
        {
            var myRowColumns = new rowColumns()
                                   {
                                       column = KeyValueMapper.FlattenPropertiesToNameValueList(messageDto)
                                   };
            var sideTable = new sideTableTable() {rows = new row[] {new row() {columns = myRowColumns}}, name= "api_promos"};
            return sideTable;
        }

        private static subscriberBase CreateSubscriber(object messageDto, bool allowResubscribe, subscriberBaseDivision division, GlobalSubscriptionState subscriptionState)
        {
            var myAttributes = new attributes()
                                   {
                                       attribute = AttributeMapper.FlattenPropertiesToNameValueList(messageDto)
                                   };

            var subscriber = new subscriberBase()
            { 
                division = division,
                allowResubscribe = allowResubscribe,
                attributes = myAttributes,
                subscriptionState = subscriptionState
            };


            return subscriber;
        }
    }
}
