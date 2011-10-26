
using System.Collections.Generic;
using System.Reflection;
using SC.YesMailAdapter.Attributes;
using System.Xml.Linq;

namespace SC.YesMailAdapter.Factory
{
    public class SubscribeAndSendMapper
    {

        private static attributes GetPropertiesAsAttributeArray(object dto)
        {
            var list = new List<attributesAttribute>();

            foreach (PropertyInfo property in dto.GetType().GetProperties())
            {
                if (property.GetCustomAttributes(typeof(SubscriberTolkenAttribute), false).Length > 0)
                {
                    AddToList(dto, list, property);
                }
            }
            var rtn = new attributes() {attribute = list.ToArray()};
            return rtn;

        }

        private static void AddToList(object dto, List<attributesAttribute> list, PropertyInfo property)
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

        private static rowColumns GetPropertiesAsRowColumn(object dto)
        {
            var list = new List<keyValue>();

            foreach (PropertyInfo property in dto.GetType().GetProperties())
            {
                if(property.GetCustomAttributes(typeof(SideTableTolkenAttribute), false).Length > 0)
                {
                    AddToList(dto, list, property);
                }
            }
            var rtn = new rowColumns() { column = list.ToArray() };
            return rtn;

        }

        private static void AddToList(object dto, List<keyValue> list, PropertyInfo property)
        {
            var propertyValue = property.GetValue(dto, null);
            if (propertyValue != null)
            {
                list.Add(new keyValue()
                             {
                                 name = property.Name.ToLower(),
                                 value = property.GetValue(dto, null).ToString()
                             });
            }
        }

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
            var myRowColumns = GetPropertiesAsRowColumn(messageDto);
            var sideTable = new sideTableTable() {rows = new row[] {new row() {columns = myRowColumns}}, name= "api_promos"};
            return sideTable;
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
