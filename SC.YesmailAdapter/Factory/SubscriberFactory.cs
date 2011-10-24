using SC.YesMailAdapter.Generated;

namespace SC.YesMailAdapter.Factory
{
    public class SubscriberFactory
    {
        public static subscribeAndSendSubscriber CreateSubscriber(EmailMessageDto messageDto)
        {
            var subscriber = new subscribeAndSendSubscriber
            {
                allowResubscribe = @"true",
                attributes = GetSubcriberAttributes(messageDto),
                division = @"Transactional",
                subscriptionState = @"SUBSCRIBED"
            };


            return subscriber;
        }

        private static subscribeAndSendSubscriberAttributesAttribute[] GetSubcriberAttributes(
    EmailMessageDto messageDto)
        {
            // Todo: pass in object for DTO and use Reflection to create attributes.
            var Email =
                new subscribeAndSendSubscriberAttributesAttribute { name = "email", value = messageDto.Email };

            var Name1 =
                new subscribeAndSendSubscriberAttributesAttribute { name = "name1", value = messageDto.Name1 };

            var Url1 =
                new subscribeAndSendSubscriberAttributesAttribute { name = "url1", value = messageDto.Url1 };

            var Url2 =
                new subscribeAndSendSubscriberAttributesAttribute { name = "url2", value = messageDto.Url2 };

            var Url3 =
                new subscribeAndSendSubscriberAttributesAttribute { name = "url3", value = messageDto.Url3 };

            var Generic1 =
                new subscribeAndSendSubscriberAttributesAttribute { name = "generic1", value = messageDto.Generic1 };

            var Generic2 =
                new subscribeAndSendSubscriberAttributesAttribute { name = "generic2", value = messageDto.Generic2 };

            var Generic3 =
                new subscribeAndSendSubscriberAttributesAttribute { name = "generic3", value = messageDto.Generic3 };

            return new[]
                       {
                           Email, Name1,
                           Url1, Url2, Url3, Generic1, Generic2, Generic3
                       };
        }
    }
}
