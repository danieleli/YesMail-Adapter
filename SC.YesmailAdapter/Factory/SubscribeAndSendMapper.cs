
using System.Collections.Generic;
using System.Reflection;

namespace SC.YesMailAdapter.Factory
{
    public class SubscribeAndSendMapper
    {

        private static attributes GetPropertiesAsAttributeArray(object dto)
        {
            var list = new List<attributesAttribute>();

            
            foreach (PropertyInfo property in dto.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(dto, null);
                if (propertyValue != null)
                {
                    list.Add(new attributesAttribute()
                                 {
                                     name = property.Name.ToLower(),
                                     value = property.GetValue(dto, null).ToString()
                                 });
                }
            }
            var rtn = new attributes() {attribute = list.ToArray()};
            return rtn;

        }

        public static subscribeAndSend CreateSendAndSubcribeMessage(object messageDto, int messageId)
        {
            bool allowResubscribe = true;
            var division = new subscriberBaseDivision() { Value = "Transactional"};
            var subscriptionState = GlobalSubscriptionState.SUBSCRIBED;

            var subscriber = SubscribeAndSendMapper.CreateSubscriber(messageDto, allowResubscribe, division, subscriptionState);

            var message = new subscribeAndSend
            {
                subscriber = subscriber,
                subscriberMessage = new subscriberMessage() { masterId = messageId }
            };
            return message;
        }

        private static subscriberBase CreateSubscriber(object messageDto, bool allowResubscribe, subscriberBaseDivision division, GlobalSubscriptionState subscriptionState)
        {
            var subscriber = new subscriberBase()
            { 
                division = division,
                allowResubscribe = allowResubscribe,
                attributes = GetPropertiesAsAttributeArray(messageDto),
                subscriptionState = subscriptionState
            };


            return subscriber;
        }
    }
}
